package via.dk.elearn.service.mapper;

import org.springframework.stereotype.Component;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.protobuf.LectureModel;
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
}
