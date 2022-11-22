package via.dk.elearn.service.mapper;

import org.springframework.stereotype.Component;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.protobuf.PostModel;

@Component
public class LectureMapper {
    public static PostModel convertLectureToGrpcModel(Lecture lecture) {
        return PostModel.newBuilder()
                .setId(lecture.getId())
                .setBody(lecture.getBody())
                .setImage(lecture.getImage())
                .setTitle(lecture.getTitle())
                .setUrl(lecture.getUrl())
                .build();
    }
    public static Lecture convertGrpcModelToLecture(PostModel postModel)
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
