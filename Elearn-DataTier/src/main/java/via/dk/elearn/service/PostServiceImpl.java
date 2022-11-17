package via.dk.elearn.service;

import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.entity.Lecture;
import via.dk.elearn.protobuf.NewPostRequest;
import via.dk.elearn.protobuf.PostGrpc;
import via.dk.elearn.protobuf.PostLookupModel;
import via.dk.elearn.protobuf.PostModel;
import via.dk.elearn.repository.LectureRepository;

import java.util.ArrayList;
import java.util.List;

@GRpcService
public class PostServiceImpl extends PostGrpc.PostImplBase {

    private LectureRepository lectureRepository;

    @Autowired
    public PostServiceImpl(LectureRepository lectureRepository) {
        this.lectureRepository = lectureRepository;
    }

    @Override
    public void getPost(PostLookupModel request, StreamObserver<PostModel> responseObserver) {

        List<Lecture> lectures = lectureRepository.findByUrl(request.getUrl());
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
