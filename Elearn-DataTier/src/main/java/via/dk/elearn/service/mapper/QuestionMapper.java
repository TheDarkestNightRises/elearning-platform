package via.dk.elearn.service.mapper;

import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.Question;
import via.dk.elearn.protobuf.PostModel;
import via.dk.elearn.protobuf.QuestionModel;

import javax.persistence.Convert;

public class QuestionMapper {
    public static QuestionModel convertLectureToGrpcModel(Question question) {
        return QuestionModel.newBuilder()
                .setId(question.getId())
                .setBody(question.getBody())
                .setTitle(question.getTitle())
                .setUrl(question.getUrl())
                .build();
    }
    public static Question convertGrpcModelToLecture(QuestionModel questionModel) {
        return Question.builder()
                .body(questionModel.getBody())
                .title(questionModel.getTitle())
                .url(questionModel.getUrl())
                .build();
    }
}