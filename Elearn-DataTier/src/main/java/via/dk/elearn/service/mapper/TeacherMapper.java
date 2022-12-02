package via.dk.elearn.service.mapper;

import via.dk.elearn.models.Teacher;
import via.dk.elearn.models.User;
import via.dk.elearn.protobuf.TeacherModel;
import via.dk.elearn.protobuf.UserModel;

public class TeacherMapper {
    public static TeacherModel convertTeacherToGrpcModel(Teacher user) {
        return TeacherModel.newBuilder()
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

    public static Teacher convertGrpcModelToTeacher(TeacherModel userModel) {
        return Teacher.builder()
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
