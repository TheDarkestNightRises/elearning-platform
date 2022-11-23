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
    public static Lecture convertGrpcModelToLecture(LectureModel postModel)
    {
        return Lecture.builder()
                .id(postModel.getId())
                .title(postModel.getTitle())
                .body(postModel.getBody())
                .image(postModel.getImage())
                .url(postModel.getUrl())
                .build();
    }
}
