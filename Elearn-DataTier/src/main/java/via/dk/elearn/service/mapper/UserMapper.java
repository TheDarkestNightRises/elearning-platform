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

}
