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
                .setImage(user.getImage())
                .setRole(user.getRole())
                .setSecurityLevel(user.getSecurity_level())
                .setApproved(user.isApproved())
                .build();
    }

    public static User convertGrpcModelToUser(UserModel userModel) {
        return User.builder()
                .id(userModel.getId())
                .username(userModel.getUsername())
                .email(userModel.getEmail())
                .name(userModel.getName())
                .password(userModel.getPassword())
                .image(userModel.getImage())
                .role(userModel.getRole())
                .security_level(userModel.getSecurityLevel())
                .build();
    }



}
