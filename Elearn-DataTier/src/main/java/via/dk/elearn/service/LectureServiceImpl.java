//package via.dk.elearn.service;
//
//import com.google.protobuf.Any;
//import com.google.rpc.ErrorInfo;
//import io.grpc.protobuf.StatusProto;
//import io.grpc.stub.StreamObserver;
//import org.lognet.springboot.grpc.GRpcService;
//import org.springframework.beans.factory.annotation.Autowired;
//import via.dk.elearn.models.Lecture;
//import via.dk.elearn.protobuf.LectureModel;
//import via.dk.elearn.protobuf.LectureServiceGrpc;
//import via.dk.elearn.protobuf.LectureUrl;
//import via.dk.elearn.protobuf.NewLectureRequest;
//import via.dk.elearn.repository.LectureRepository;
//import via.dk.elearn.service.mapper.LectureMapper;
//
//import java.util.List;
//import java.util.Optional;
//
//@GRpcService
//public class LectureServiceImpl extends LectureServiceGrpc.LectureServiceImplBase {
//
//    private LectureRepository lectureRepository;
//
//    @Autowired
//    public LectureServiceImpl(LectureRepository lectureRepository) {
//        this.lectureRepository = lectureRepository;
//    }
//
//    @Override
//    public void getLecture(LectureUrl request, StreamObserver<LectureModel> responseObserver) {
//        List<Lecture> lectures = lectureRepository.findByUrl(request.getUrl());
//        if (lectures.isEmpty()) {
//            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
//                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
//                    .setMessage("The lecture is not found")
//                    .addDetails(Any.pack(ErrorInfo.newBuilder()
//                            .setReason("Lecture not found")
//                            .build()))
//                    .build();
//            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
//            return;
//        }
//        Lecture lecture = lectures.get(0);
//        PostModel postModel = LectureMapper.convertLectureToGrpcModel(lecture);
//        responseObserver.onNext(postModel);
//        responseObserver.onCompleted();
//    }
//
//    @Override
//    public void getAllLectures(NewLectureRequest request, StreamObserver<LectureModel> responseObserver) {
//        List<Lecture> lectures = lectureRepository.findAll();
//        if (lectures.isEmpty()) {
//            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
//                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
//                    .setMessage("The lectures are not found")
//                    .addDetails(Any.pack(ErrorInfo.newBuilder()
//                            .setReason("Lectures not found")
//                            .build()))
//                    .build();
//            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
//            return;
//        }
//        for(Lecture lecture : lectures) {
//            PostModel postModel = LectureMapper.convertLectureToGrpcModel(lecture);
//            responseObserver.onNext(postModel);
//        }
//        responseObserver.onCompleted();
//    }
//
//    @Override
//    public void createNewPost(PostModel request, StreamObserver<PostModel> responseObserver) {
//        Lecture lecture = new Lecture(request.getTitle(), request.getUrl(), request.getImage(),request.getBody());
//        Lecture lectureFromDb = lectureRepository.save(lecture);
//        PostModel postModel = LectureMapper.convertLectureToGrpcModel(lectureFromDb);
//        responseObserver.onNext(postModel);
//        responseObserver.onCompleted();
//    }
//
//    @Override
//    public void getById(PostId request, StreamObserver<PostModel> responseObserver) {
//        Optional<Lecture> lectures = lectureRepository.findById(request.getId());
//        if (lectures.isEmpty()) {
//            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
//                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
//                    .setMessage("The lecture is not found")
//                    .addDetails(Any.pack(ErrorInfo.newBuilder()
//                            .setReason("Lecture not found")
//                            .build()))
//                    .build();
//            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
//        }
//        else {
//            Lecture lecture = lectures.get();
//            PostModel postModel = LectureMapper.convertLectureToGrpcModel(lecture);
//            responseObserver.onNext(postModel);
//            responseObserver.onCompleted();
//        }
//    }
//}
