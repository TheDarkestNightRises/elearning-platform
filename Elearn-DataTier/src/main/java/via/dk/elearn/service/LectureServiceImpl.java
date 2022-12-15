package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.Code;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.Teacher;
import via.dk.elearn.models.User;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.LectureRepository;
import via.dk.elearn.repository.TeacherRepository;
import via.dk.elearn.service.mapper.LectureMapper;
import via.dk.elearn.service.mapper.TeacherMapper;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@GRpcService
public class LectureServiceImpl extends LectureServiceGrpc.LectureServiceImplBase {

    private LectureRepository lectureRepository;
    private TeacherRepository teacherRepository;

    @Autowired
    public LectureServiceImpl(LectureRepository lectureRepository, TeacherRepository teacherRepository) {
        this.lectureRepository = lectureRepository;
        this.teacherRepository = teacherRepository;
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
    public void getAllLectures(PaginationModel request, StreamObserver<LectureModel> responseObserver) {

        List<Lecture> lectures = lectureRepository.findAll();
        for (Lecture lecture : lectures) {
            LectureModel lectureModel = LectureMapper.convertLectureToGrpcModel(lecture);
            responseObserver.onNext(lectureModel);
        }
        responseObserver.onCompleted();
    }

    @Override
    public void createNewLecture(LectureModel request, StreamObserver<LectureModel> responseObserver) {
        Lecture lecture = LectureMapper.convertGrpcModelToLecture(request);


        Lecture lectureFromDb = lectureRepository.save(lecture);

        LectureModel lectureModel = LectureMapper.convertLectureToGrpcModel(lectureFromDb);

        responseObserver.onNext(lectureModel);
        responseObserver.onCompleted();
    }


    @Override
    public void getLectureById(LectureId request, StreamObserver<LectureModel> responseObserver) {
        Optional<Lecture> lectures = lectureRepository.findById(request.getId());

            Lecture lecture = lectures.get();
            LectureModel lectureModel = LectureMapper.convertLectureToGrpcModel(lecture);
            responseObserver.onNext(lectureModel);
            responseObserver.onCompleted();

    }

    @Override
    public void getLectureByUserId(LectureUserId request, StreamObserver<LectureModel> responseObserver) {
        Optional<Teacher> teacher = teacherRepository.findById(request.getUserId());
        if (teacher.isEmpty()) {
            responseObserver.onCompleted();
        } else {
            List<Lecture> lectures = lectureRepository.findAllByTeacher(teacher.get());
            for (Lecture lecture : lectures) {
                LectureModel lectureModel = LectureMapper.convertLectureToGrpcModel(lecture);
                responseObserver.onNext(lectureModel);
            }
            responseObserver.onCompleted();
        }
    }

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
        } else {
            for (Lecture lecture : lectures) {
                LectureModel lectureModel = LectureMapper.convertLectureToGrpcModel(lecture);
                responseObserver.onNext(lectureModel);
            }
            responseObserver.onCompleted();
        }
    }

    @Override
    public void editLecture(LectureModel request, StreamObserver<LectureModel> responseObserver) {
        Lecture lecture = LectureMapper.convertGrpcModelToLecture(request);
        try
        {
            Lecture lectureFromDb = lectureRepository.save(lecture);

            LectureModel lectureModel = LectureMapper.convertLectureToGrpcModel(lectureFromDb);
            responseObserver.onNext(lectureModel);
            responseObserver.onCompleted();
        }catch (Exception e)
        {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(Code.INVALID_ARGUMENT.getNumber())
                    .setMessage("Cannot edit lecture")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Cannot edit lecture")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            e.printStackTrace();
        }
    }

    @Override
    public void deleteLecture(LectureModel request, StreamObserver<LectureResponse> responseObserver) {

        Optional<Lecture> findLecture = lectureRepository.findById(request.getId());
        Lecture lectureFound = findLecture.get();
        lectureRepository.delete(lectureFound);
        responseObserver.onNext(null);
        responseObserver.onCompleted();

    }

}
