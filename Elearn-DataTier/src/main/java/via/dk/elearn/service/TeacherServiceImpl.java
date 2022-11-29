package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.Teacher;
import via.dk.elearn.models.User;
import via.dk.elearn.protobuf.TeacherModel;
import via.dk.elearn.protobuf.TeacherServiceGrpc;
import via.dk.elearn.protobuf.UserModel;
import via.dk.elearn.protobuf.UserName;
import via.dk.elearn.repository.TeacherRepository;
import via.dk.elearn.service.mapper.TeacherMapper;
import via.dk.elearn.service.mapper.UserMapper;

import java.util.List;

@GRpcService
public class TeacherServiceImpl extends TeacherServiceGrpc.TeacherServiceImplBase {

    private TeacherRepository teacherRepository;

    @Autowired
    public TeacherServiceImpl(TeacherRepository teacherRepository) {
        this.teacherRepository = teacherRepository;
    }

    @Override
    public void getTeacherByUsername(UserName request, StreamObserver<TeacherModel> responseObserver) {
        List<Teacher> teachers = teacherRepository.findByUsername(request.getUsername());
        if (teachers.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The teacher is not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("User not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }
        Teacher teacher = teachers.get(0);
        TeacherModel teacherModel = TeacherMapper.convertTeacherToGrpcModel(teacher);
        responseObserver.onNext(teacherModel);
        responseObserver.onCompleted();
    }
}
