package via.dk.elearn.service.mapper;

import via.dk.elearn.models.Answer;
import via.dk.elearn.models.Comment;
import via.dk.elearn.protobuf.AnswerModel;
import via.dk.elearn.protobuf.CommentModel;

public class AnswerMapper {

    public static AnswerModel convertAnswerToGrpcModel(Answer answer) {
        return AnswerModel.newBuilder()
                .setId(answer.getId())
                .setAuthor(UserMapper.convertUserToGrpcModel(answer.getUser()))
                .setQuestion(QuestionMapper.convertQuestionToGrpcModel(answer.getQuestion()))
                .setText(answer.getBody())
                .setDate(DateMapper.convertDateToGrpcModel(answer.getPublished_date()))
                .build();
    }

    public static Answer convertGrpcModelToAnswer(AnswerModel answerModel)
    {
        return Answer.builder()
                .id(answerModel.getId())
                .user(UserMapper.convertGrpcModelToUser(answerModel.getAuthor()))
                .question(QuestionMapper.convertGrpcModelToQuestion(answerModel.getQuestion()))
                .body(answerModel.getText())
                .published_date(DateMapper.convertGrpcModeltoDate(answerModel.getDate()))
                .build();
    }
}
