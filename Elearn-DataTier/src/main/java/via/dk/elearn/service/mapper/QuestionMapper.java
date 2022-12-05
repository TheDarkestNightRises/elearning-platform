package via.dk.elearn.service.mapper;

import via.dk.elearn.models.Question;
import via.dk.elearn.protobuf.QuestionModel;

public class QuestionMapper {
    public static QuestionModel convertQuestionToGrpcModel(Question question) {
        return QuestionModel.newBuilder()
                .setId(question.getId())
                .setBody(question.getBody())
                .setTitle(question.getTitle())
                .setUrl(question.getUrl())
                .build();
    }

    public static Question convertGrpcModelToQuestion(QuestionModel questionModel) {
        return Question.builder()
                .body(questionModel.getBody())
                .title(questionModel.getTitle())
                .url(questionModel.getUrl())
                .build();
    }
}