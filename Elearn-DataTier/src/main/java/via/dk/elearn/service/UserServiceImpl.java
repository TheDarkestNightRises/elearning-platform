package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.User;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.UserRepository;
import via.dk.elearn.service.mapper.UserMapper;

import java.util.List;
import java.util.Optional;

@GRpcService
public class UserServiceImpl extends UserServiceGrpc.UserServiceImplBase {

    private UserRepository userRepository;
    @Autowired
    public UserServiceImpl(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    @Override
        public void getUserByName(via.dk.elearn.protobuf.UserName request, StreamObserver<UserModel> responseObserver) {
        List<User> users = userRepository.findByUsername(request.getName());
        if (users.isEmpty()) {
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
        User user = users.get(0);
        UserModel userModel = UserMapper.convertUserToGrpcModel(user);
        responseObserver.onNext(userModel);
        responseObserver.onCompleted();    }



    @Override
    public void createNewUser(UserModel request, StreamObserver<UserModel> responseObserver) {
        User user = UserMapper.convertGrpcModelToUser(request);
        User userFromDb = userRepository.save(user);
        UserModel userModel = UserMapper.convertUserToGrpcModel(userFromDb);
        responseObserver.onNext(userModel);
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
