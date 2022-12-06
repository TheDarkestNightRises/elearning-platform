package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.University;
import via.dk.elearn.models.User;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.LectureRepository;
import via.dk.elearn.repository.UniversityRepository;
import via.dk.elearn.service.mapper.LectureMapper;
import via.dk.elearn.service.mapper.UniversityMapper;
import via.dk.elearn.service.mapper.UserMapper;

import java.util.List;
import java.util.Optional;

@GRpcService
public class UniversityServiceImpl extends UniversityServiceGrpc.UniversityServiceImplBase {

    private UniversityRepository universityRepository;
    private LectureRepository lectureRepository;
    @Autowired
    public UniversityServiceImpl(UniversityRepository universityRepository, LectureRepository lectureRepository) {
        this.universityRepository = universityRepository;
        this.lectureRepository = lectureRepository;
    }
    @Override
    public void getLecturesByUniversity(UniversityModel request, StreamObserver<LectureModel> responseObserver) {
        List<Lecture> lectures = lectureRepository.findAllByTeacher_University(UniversityMapper.convertGrpcModelToUniversity(request));
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
    public void getUniversities(UniversityRequest request, StreamObserver<UniversityModel> responseObserver) {
        List<University> universities = universityRepository.findAll();
        if (universities.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("No universities were not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Universities not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }
        for(University university : universities) {
            UniversityModel universityModel = UniversityMapper.convertUniversityToGrpcModel(university);
            responseObserver.onNext(universityModel);
        }
        responseObserver.onCompleted();
    }

    @Override
    public void getUniversityById(UniversityId request, StreamObserver<UniversityModel> responseObserver) {
        Optional<University> university = universityRepository.findById(request.getId());
        if(university.isEmpty())
        {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The requested user was not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("User not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
        }
        else
        {
            University universityFound = university.get();
            UniversityModel universityModel = UniversityMapper.convertUniversityToGrpcModel(universityFound);
            responseObserver.onNext(universityModel);
            responseObserver.onCompleted();
        }
    }
}
