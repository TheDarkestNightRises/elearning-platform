package via.dk.elearn.service;

import io.grpc.stub.StreamObserver;
import org.apache.catalina.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.security.SecurityProperties;
import via.dk.elearn.entity.Lecture;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.LectureRepository;
import via.dk.elearn.repository.UserRepository;

import java.util.List;

public class UserServiceImpl extends UserGrpc.UserImplBase {
    private UserRepository userRepository;

    @Autowired
    public UserServiceImpl(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    @Override
    public void getUserByName(Username request, StreamObserver<UserModel> responseObserver) {
        super.getUserByName(request, responseObserver);
    }

    @Override
    public void createNewUser(UserLookupModel request, StreamObserver<UserModel> responseObserver) {
        super.createNewUser(request, responseObserver);
    }

//    @Override
//    public void getUserByID(UserLookupModel request, StreamObserver<UserModel> responseObserver) {
//        List<User> users = userRepository.findById(request.getId());
//        User user = users.get(0);
//        UserModel userModel = PostModel.newBuilder()
//                .setId(user.getId())
//                .setUsername(user.getUsername())
//                .setEmail(user.getEmail())
//                        .setPassword(user.getPassword())
//                                .setFirstName(user.getFirstName())
//                                        .setLastName(user.getLastName())
//                                                .setCountry(user.getCountry())
//                                                        .setRole(user.getRoles()).build();
//        responseObserver.onNext(userModel);
//        responseObserver.onCompleted();
//
//
//    }
}
