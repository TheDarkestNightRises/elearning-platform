package via.dk.elearn.service.mapper;

import org.springframework.stereotype.Component;
import via.dk.elearn.models.Teacher;
import via.dk.elearn.models.University;
import via.dk.elearn.protobuf.TeacherModel;
import via.dk.elearn.protobuf.UniversityModel;

@Component
public class UniversityMapper {
    public static UniversityModel convertUniversityToGrpcModel(University university) {
        return UniversityModel.newBuilder()
                .setId(university.getId())
                .setName(university.getUniversityName())
                .setDescription(university.getDescription())
                .build();
    }
    public static University convertGrpcModelToUniversity(UniversityModel model) {
        return University.builder()
                .id(model.getId())
                .universityName(model.getName())
                .description(model.getDescription())
                .build();
    }
}
