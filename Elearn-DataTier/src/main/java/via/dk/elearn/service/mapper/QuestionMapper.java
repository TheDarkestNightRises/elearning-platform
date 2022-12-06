package via.dk.elearn.service.mapper;

import via.dk.elearn.models.Question;
import via.dk.elearn.protobuf.QuestionModel;

public class QuestionMapper {
    public static QuestionModel convertQuestionToGrpcModel(Question question) {
        return QuestionModel.newBuilder()
                .setId(question.getId())
                .setBody(question.getBody())
                .setTitle(question.getTitle())
                .setDescription(question.getDescription())
                .setUrl(question.getUrl())
                .setDateCreated(DateMapper.convertDateToGrpcModel(question.getDate()))
                .setStudent(StudentMapper.convertUserToGrpcModel(question.getStudent()))
                .build();
    }

    public static Question convertGrpcModelToQuestion(QuestionModel questionModel) {
        return Question.builder()
                .id(questionModel.getId())
                .body(questionModel.getBody())
                .title(questionModel.getTitle())
                .url(questionModel.getUrl())
                .date(DateMapper.convertGrpcModeltoDate(questionModel.getDateCreated()))
                .student(StudentMapper.convertGrpcModelToUser(questionModel.getStudent()))
                .build();
    }
}