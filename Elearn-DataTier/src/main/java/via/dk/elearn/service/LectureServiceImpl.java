package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.Teacher;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.LectureRepository;
import via.dk.elearn.service.mapper.LectureMapper;
import via.dk.elearn.service.mapper.TeacherMapper;

import java.util.List;
import java.util.Optional;

@GRpcService
public class LectureServiceImpl extends LectureServiceGrpc.LectureServiceImplBase {

    private LectureRepository lectureRepository;

    @Autowired
    public LectureServiceImpl(LectureRepository lectureRepository) {
        this.lectureRepository = lectureRepository;
    }

    @Override
    public void getLecture(LectureUrl request, StreamObserver<LectureModel> responseObserver) {
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
        LectureModel lectureModel = LectureMapper.convertLectureToGrpcModel(lecture);
        responseObserver.onNext(lectureModel);
        responseObserver.onCompleted();
    }

    @Override
    public void getAllLectures(NewLectureRequest request, StreamObserver<LectureModel> responseObserver) {
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
            LectureModel lectureModel = LectureMapper.convertLectureToGrpcModel(lecture);
            responseObserver.onNext(lectureModel);
        }
        responseObserver.onCompleted();
    }

    @Override
    public void createNewLecture(LectureModel request, StreamObserver<LectureModel> responseObserver) {
        Lecture lecture = LectureMapper.convertGrpcModelToLecture(request);
        //Teacher teacher = TeacherMapper.convertGrpcModelToTeacher(request.getTeacher());
        //lecture.setTeacher(teacher);

        Lecture lectureFromDb = lectureRepository.save(lecture);
        //lectureFromDb.setTeacher(teacher);
        LectureModel lectureModel = LectureMapper.convertLectureToGrpcModel(lectureFromDb);
        //LectureModel lectureModel1 = LectureModel.newBuilder(lectureModel).setTeacher(request.getTeacher()).build();
        responseObserver.onNext(lectureModel);
        responseObserver.onCompleted();
    }



    @Override
    public void getLectureById(LectureId request, StreamObserver<LectureModel> responseObserver) {
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
            LectureModel lectureModel = LectureMapper.convertLectureToGrpcModel(lecture);
            responseObserver.onNext(lectureModel);
            responseObserver.onCompleted();
        }
    }

    @Override
    public void getLectureByUserId(LectureUserId request, StreamObserver<LectureModel> responseObserver) {
        List<Lecture> lectures = lectureRepository.findUserLecturesById(request.getUserId());
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
            Lecture lecture = lectures.get(0);
            LectureModel lectureModel = LectureMapper.convertLectureToGrpcModel(lecture);
            responseObserver.onNext(lectureModel);
            responseObserver.onCompleted();
        }   }

    @Override
    public void getUpvotedLectureByUserId(LectureUserId request, StreamObserver<LectureModel> responseObserver) {
        List<Lecture> lectures = lectureRepository.findUpvotedLecturesOfUser(request.getUserId());
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
            Lecture lecture = lectures.get(0);
            LectureModel lectureModel = LectureMapper.convertLectureToGrpcModel(lecture);
            responseObserver.onNext(lectureModel);
            responseObserver.onCompleted();
        }    }
}
