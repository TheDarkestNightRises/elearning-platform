package via.dk.elearn.service.mapper;

import org.springframework.stereotype.Component;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.protobuf.LectureModel;

@Component
public class LectureMapper {
    public static LectureModel convertLectureToGrpcModel(Lecture lecture) {
        return LectureModel.newBuilder()
                .setId(lecture.getId())
                .setBody(lecture.getBody())
                .setImage(lecture.getImage())
                .setTitle(lecture.getTitle())
                .setUrl(lecture.getUrl())
                .build();
    }
    public static Lecture convertGrpcModelToLecture(LectureModel lectureModel)
    {
        return Lecture.builder()
                .id(lectureModel.getId())
                .title(lectureModel.getTitle())
                .body(lectureModel.getBody())
                .image(lectureModel.getImage())
                .url(lectureModel.getUrl())
                .teacher(TeacherMapper.convertGrpcModelToTeacher(lectureModel.getTeacher()))
                .build();
    }
}
