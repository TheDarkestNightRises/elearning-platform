package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.Teacher;
import via.dk.elearn.models.University;
import via.dk.elearn.models.User;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.TeacherRepository;
import via.dk.elearn.repository.UserRepository;
import via.dk.elearn.service.mapper.UniversityMapper;
import via.dk.elearn.service.mapper.UserMapper;

import java.util.List;
import java.util.Optional;

@GRpcService
public class UserServiceImpl extends UserServiceGrpc.UserServiceImplBase {

    private UserRepository userRepository;
    private TeacherRepository teacherRepository;
    @Autowired
    public UserServiceImpl(UserRepository userRepository,TeacherRepository teacherRepository) {
        this.userRepository = userRepository;
        this.teacherRepository = teacherRepository;
    }

    @Override
        public void getUserByName(via.dk.elearn.protobuf.Name request, StreamObserver<UserModel> responseObserver) {

        Optional<User> user = userRepository.findFirstByName(request.getName());

        if (user.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The user is not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("User not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }

        UserModel userModel = UserMapper.convertUserToGrpcModel(user.get());
        responseObserver.onNext(userModel);
        responseObserver.onCompleted();
    }

    @Override
    public void getUserByUsername(via.dk.elearn.protobuf.UserName request, StreamObserver<UserModel> responseObserver) {

        Optional<User> user = userRepository.findFirstByUsername(request.getUsername());
        if (user.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The user is not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("User not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }

        UserModel userModel = UserMapper.convertUserToGrpcModel(user.get());
        responseObserver.onNext(userModel);
        responseObserver.onCompleted();    }




    @Override
    public void createNewUser(UserModel request, StreamObserver<UserModel> responseObserver) {
        User user = UserMapper.convertGrpcModelToUser(request);
        University university = UniversityMapper.convertGrpcModelToUniversity(request.getUniversity());
        user.setUniversity(university);
        UserModel userModel;
        if(user.getRole().equals("Teacher"))
        {
            Teacher teacher = new Teacher(user.getId(), user.getUsername(),user.getEmail(), user.getName(), user.getPassword(), user.getRole(), user.getSecurity_level(), user.getUniversity());
            Teacher teacherFromDB = teacherRepository.save(teacher);
            userModel = UserMapper.convertUserToGrpcModel(teacherFromDB);
        }
        else
        {
            User userFromDb = userRepository.saveAndFlush(user);
            userModel = UserMapper.convertUserToGrpcModel(userFromDb);
        }
        userModel = UserModel.newBuilder(userModel)
                .setUniversity(request.getUniversity())
                .build();
        responseObserver.onNext(userModel);
        responseObserver.onCompleted();
    }

    @Override
    public void updateUser(UserModel request, StreamObserver<UserModel> responseObserver) {

            Optional<User> findUser = userRepository.findById(request.getId());
            User userFound = findUser.get();
            userFound.setPassword(request.getPassword());
            userFound.setEmail(request.getEmail());
            userRepository.save(userFound);
            UserModel userModel = UserMapper.convertUserToGrpcModel(userFound);
            responseObserver.onNext(userModel);
            responseObserver.onCompleted();
        }


    @Override
    public void deleteUser(UserModel request, StreamObserver<Nothing> responseObserver) {
        Optional<User> findUser = userRepository.findById(request.getId());
        User userFound = findUser.get();
        userRepository.delete(userFound);

        responseObserver.onNext(null);
        responseObserver.onCompleted();
    }

    @Override
    public void getUserByID(UserId request, StreamObserver<UserModel> responseObserver) {
        Optional<User> user = userRepository.findById(request.getId());
        if(user.isEmpty())
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
            User userFound = user.get();
            UserModel userModel = UserMapper.convertUserToGrpcModel(userFound);
            responseObserver.onNext(userModel);
            responseObserver.onCompleted();
        }
    }
}
