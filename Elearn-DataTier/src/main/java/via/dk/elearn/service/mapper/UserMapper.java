package via.dk.elearn.service.mapper;

import via.dk.elearn.models.User;
import via.dk.elearn.protobuf.UserModel;

public class UserMapper {
    public static UserModel convertUserToGrpcModel(User user) {
        return UserModel.newBuilder()
                .setId(user.getId())
                .setUsername(user.getUsername())
                .setEmail(user.getEmail())
                .setName(user.getName())
                .setPassword(user.getPassword())
                .setRole(user.getRole())
                .setSecurityLevel(user.getSecurity_level())
                .build();
    }

    public static User convertGrpcModelToUser(UserModel userModel) {
        return User.builder()
                .username(userModel.getUsername())
                .email(userModel.getEmail())
                .name(userModel.getName())
                .password(userModel.getPassword())
                .role(userModel.getRole())
                .security_level(userModel.getSecurityLevel())
                .build();
    }



}
