package via.dk.elearn.service.mapper;

import org.springframework.stereotype.Component;
import via.dk.elearn.models.Comment;
import via.dk.elearn.protobuf.CommentModel;

@Component
public class CommentMapper {

    public static CommentModel convertCommentToGrpcModel(Comment comment) {
        return CommentModel.newBuilder()
                .setId(comment.getId())
                .setAuthor(UserMapper.convertUserToGrpcModel(comment.getUser()))
                .setLecture(LectureMapper.convertLectureToGrpcModel(comment.getLecture()))
                .setText(comment.getText())
                .setDate(DateMapper.convertDateToGrpcModel(comment.getPublished_date()))
                .build();
    }

    public static Comment convertGrpcModelToComment(CommentModel commentModel)
    {
        return Comment.builder()
                .id(commentModel.getId())
                .user(UserMapper.convertGrpcModelToUser(commentModel.getAuthor()))
                .lecture(LectureMapper.convertGrpcModelToLecture(commentModel.getLecture()))
                .text(commentModel.getText())
                .published_date(DateMapper.convertGrpcModeltoDate(commentModel.getDate()))
                .build();
    }
}
