package via.dk.elearn.service.mapper;

import via.dk.elearn.models.Student;
import via.dk.elearn.models.User;
import via.dk.elearn.protobuf.StudentModel;
import via.dk.elearn.protobuf.UserModel;

public class StudentMapper {
    public static StudentModel convertUserToGrpcModel(Student student) {
        return StudentModel.newBuilder()
                .setId(student.getId())
                .setUsername(student.getUsername())
                .setEmail(student.getEmail())
                .setName(student.getName())
                .setPassword(student.getPassword())
                .setImage(student.getImage())
                .setRole(student.getRole())
                .setSecurityLevel(student.getSecurity_level())
                .setApproved(student.isApproved())
                .build();
    }

    public static Student convertGrpcModelToUser(StudentModel studentModel) {
        return Student.builder()
                .id(studentModel.getId())
                .username(studentModel.getUsername())
                .email(studentModel.getEmail())
                .name(studentModel.getName())
                .password(studentModel.getPassword())
                .image(studentModel.getImage())
                .role(studentModel.getRole())
                .security_level(studentModel.getSecurityLevel())
                .build();
    }
}
