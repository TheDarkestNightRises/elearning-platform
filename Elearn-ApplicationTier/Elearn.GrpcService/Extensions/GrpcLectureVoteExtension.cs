using Elearn.Shared.Models;
using ElearnGrpc;

namespace Elearn.GrpcService.Extensions;

public static class GrpcLectureVoteExtension
{
    public static VoteModel AsGrpcModel(this LectureVote lectureVote)
    {
        return new VoteModel
        {
           User = lectureVote.User.AsGrpcModel(),
           Lecture = lectureVote.Lecture.AsGrpcModel(),
           Upvote = lectureVote.Upvote.Value
        };
    }

    public static LectureVote AsBase(this VoteModel voteModel)
    {
        return new LectureVote
        {
           User = voteModel.User is null ? null : voteModel.User.AsBase(),
           Lecture = voteModel.Lecture is null ? null : voteModel.Lecture.AsBase(),
           Upvote = voteModel.Upvote
        };
    }
}