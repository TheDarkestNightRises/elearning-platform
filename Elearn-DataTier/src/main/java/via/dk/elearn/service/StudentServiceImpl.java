package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.Student;
import via.dk.elearn.models.Teacher;
import via.dk.elearn.protobuf.StudentModel;
import via.dk.elearn.protobuf.StudentServiceGrpc;
import via.dk.elearn.protobuf.StudentUsername;
import via.dk.elearn.protobuf.TeacherModel;
import via.dk.elearn.repository.StudentRepository;
import via.dk.elearn.service.mapper.StudentMapper;
import via.dk.elearn.service.mapper.TeacherMapper;

import java.util.List;

@GRpcService
public class StudentServiceImpl extends StudentServiceGrpc.StudentServiceImplBase {

    private StudentRepository studentRepository;

    @Autowired
    public StudentServiceImpl(StudentRepository studentRepository) {
        this.studentRepository = studentRepository;
    }

    @Override
    public void getStudentByUsername(StudentUsername request, StreamObserver<StudentModel> responseObserver) {
        Student student = studentRepository.findFirstByUsername(request.getUsername());
        if (student == null) {
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
        StudentModel studentModel = StudentMapper.convertUserToGrpcModel(student);
        responseObserver.onNext(studentModel);
        responseObserver.onCompleted();
    }
}
