package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.protobuf.PostLookupModel;
import via.dk.elearn.protobuf.PostModel;
import via.dk.elearn.protobuf.PostServiceGrpc;
import via.dk.elearn.repository.LectureRepository;

import java.util.List;

@GRpcService
public class PostServiceImpl extends PostServiceGrpc.PostServiceImplBase {

    private LectureRepository lectureRepository;

    @Autowired
    public PostServiceImpl(LectureRepository lectureRepository) {
        this.lectureRepository = lectureRepository;
    }

    @Override
    public void getPost(PostLookupModel request, StreamObserver<PostModel> responseObserver) {
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
                .setTitle(lecture.getTitle()).build();
        responseObserver.onNext(postModel);
        responseObserver.onCompleted();
    }

//    @Override
//    public void getAllPost(NewPostRequest request, StreamObserver<PostModel> responseObserver) {
//        lectureRepository.findAll();
//        responseObserver.onNext(productDto);
//        responseObserver.onCompleted();
//    }
}
