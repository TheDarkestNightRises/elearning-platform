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
        List<via.dk.elearn.models.User> users = userRepository.findByUsername(request.getName());
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
        UserModel userModel = UserModel.newBuilder()
                .setId(user.getId())
                .setUsername(user.getUsername())
                .setEmail(user.getEmail())
                .setPassword(user.getPassword())
                .setRole(user.getRole())
                .build();
        responseObserver.onNext(userModel);
        responseObserver.onCompleted();    }



    @Override
    public void createNewUser(UserModel request, StreamObserver<UserModel> responseObserver) {
        User user = new User(request.getUsername(), request.getEmail(), request.getPassword(), request.getRole(),request.getSecurityLevel());
        User userFromDb = userRepository.save(user);
        UserModel userModel = UserModel.newBuilder()
                .setId(userFromDb.getId())
                .setUsername(user.getUsername())
                .setEmail(user.getEmail())
                .setPassword(user.getPassword())
                .setRole(user.getRole())
                .build();
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
            User user1 = user.get();
            UserModel userModel = UserModel.newBuilder()
                    .setId(user1.getId())
                    .setUsername(user1.getUsername())
                    .setPassword(user1.getPassword())
                    .setRole(user1.getRole())
                    .setEmail(user1.getEmail())
                    .build();
            responseObserver.onNext(userModel);
            responseObserver.onCompleted();
        }
    }
}
