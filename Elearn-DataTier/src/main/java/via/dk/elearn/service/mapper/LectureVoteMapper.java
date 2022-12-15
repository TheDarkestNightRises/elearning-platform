package via.dk.elearn.service.mapper;

import org.springframework.stereotype.Component;
import via.dk.elearn.models.LectureVote;
import via.dk.elearn.protobuf.VoteModel;

@Component
public class LectureVoteMapper {
    public static VoteModel convertLectureVoteToGrpcModel(LectureVote lectureVote) {
        return VoteModel.newBuilder()
                .setPost(LectureMapper.convertLectureToGrpcModel(lectureVote.getLecture()))
                .setUser(UserMapper.convertUserToGrpcModel(lectureVote.getUser()))
                .setUpvote(lectureVote.isUpvote()).build();
    }
    public static LectureVote convertGrpcModelToLectureVote(VoteModel voteModel){
        return LectureVote.builder()
                .lecture(LectureMapper.convertGrpcModelToLecture(voteModel.getPost()))
                .user(UserMapper.convertGrpcModelToUser(voteModel.getUser()))
                .upvote(voteModel.getUpvote())
                .build();
    }
}
