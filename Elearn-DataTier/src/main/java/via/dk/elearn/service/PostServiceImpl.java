package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.LectureRepository;

import java.util.List;
import java.util.Optional;

@GRpcService
public class PostServiceImpl extends PostServiceGrpc.PostServiceImplBase {

    private LectureRepository lectureRepository;

    @Autowired
    public PostServiceImpl(LectureRepository lectureRepository) {
        this.lectureRepository = lectureRepository;
    }

    @Override
    public void getPost(PostUrl request, StreamObserver<PostModel> responseObserver) {
        List<Lecture> lectures = lectureRepository.findByUrl(request.getUrl());
        if (lectures.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The lecture is not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Lecture not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }
        Lecture lecture = lectures.get(0);
        PostModel postModel = PostModel.newBuilder()
                .setId(lecture.getId())
                .setBody(lecture.getBody())
                .setTitle(lecture.getTitle())
                .setUrl(lecture.getUrl())
                .build();
        responseObserver.onNext(postModel);
        responseObserver.onCompleted();
    }

    @Override
    public void getAllPost(NewPostRequest request, StreamObserver<PostModel> responseObserver) {
        List<Lecture> lectures = lectureRepository.findAll();
        if (lectures.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The lectures are not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Lectures not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }
        for(Lecture lecture : lectures) {
            PostModel postModel = PostModel.newBuilder()
                    .setId(lecture.getId())
                    .setBody(lecture.getBody())
                    .setTitle(lecture.getTitle())
                    .setUrl(lecture.getUrl())
                    .build();
            responseObserver.onNext(postModel);
        }
        responseObserver.onCompleted();
    }

    @Override
    public void createNewPost(PostModel request, StreamObserver<PostModel> responseObserver) {
        Lecture lecture = new Lecture(request.getTitle(), request.getUrl(), request.getImage(),request.getBody());
        Lecture lectureFromDb = lectureRepository.save(lecture);
        PostModel postModel = PostModel.newBuilder()
                .setId(lectureFromDb.getId())
                .setBody(lectureFromDb.getBody())
                .setTitle(lectureFromDb.getTitle())
                .setImage(lectureFromDb.getImage())
                .setUrl(lectureFromDb.getUrl())
                .build();
        responseObserver.onNext(postModel);
        responseObserver.onCompleted();
    }

    @Override
    public void getById(PostId request, StreamObserver<PostModel> responseObserver) {
        Optional<Lecture> lectures = lectureRepository.findById(request.getId());
        if (lectures.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The lecture is not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Lecture not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
        }
        else {
            Lecture lecture = lectures.get();
            PostModel postModel = PostModel.newBuilder()
                    .setId(lecture.getId())
                    .setBody(lecture.getBody())
                    .setTitle(lecture.getTitle())
                    .setImage(lecture.getImage())
                    .setUrl(lecture.getUrl())
                    .build();
            responseObserver.onNext(postModel);
            responseObserver.onCompleted();
        }
    }
}
