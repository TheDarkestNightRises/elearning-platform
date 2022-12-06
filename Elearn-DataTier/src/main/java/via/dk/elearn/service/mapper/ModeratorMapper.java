package via.dk.elearn.service.mapper;

import via.dk.elearn.models.Moderator;
import via.dk.elearn.protobuf.ModeratorModel;

public class ModeratorMapper {
    public static ModeratorModel convertModeratorToGrpcModel(Moderator user) {
        return ModeratorModel.newBuilder()
                .setId(user.getId())
                .setUsername(user.getUsername())
                .setEmail(user.getEmail())
                .setName(user.getName())
                .setPassword(user.getPassword())
                .setImage(user.getImage())
                .setRole(user.getRole())
                .setSecurityLevel(user.getSecurity_level())
                .build();
    }

    public static Moderator convertGrpcModelToModerator(ModeratorModel userModel) {
        return Moderator.builder()
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
