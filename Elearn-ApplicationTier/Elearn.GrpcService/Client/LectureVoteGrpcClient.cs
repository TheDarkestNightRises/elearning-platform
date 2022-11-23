using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Extensions;
using Elearn.Shared.Models;
using ElearnGrpc;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;

namespace Elearn.GrpcService.Client;

public class LectureVoteGrpcClient : ILectureVoteService
{
    private LectureVoteService.LectureVoteServiceClient _lectureVoteGrpcClient;

    public LectureVoteGrpcClient()
    {
        var _grpcChannel =
            new Channel("localhost:8843", ChannelCredentials.Insecure);
        _lectureVoteGrpcClient = new LectureVoteService.LectureVoteServiceClient(_grpcChannel);
    }

    public async Task<LectureVote> CreateLectureVoteAsync(LectureVote lectureVote)
    {
        VoteModel model = new VoteModel();
        model.Lecture = GrpcLectureExtension.AsGrpcModel(lectureVote.Lecture);
        model.User = GrpcUserExtension.AsGrpcModel(lectureVote.User);
        model.Upvote = lectureVote.Upvote;
        VoteModel createdVoteModel = await _lectureVoteGrpcClient.VoteLectureAsync(model);
        User userFromResponse = GrpcUserExtension.AsBase(createdVoteModel.User);
        Lecture lectureFromResponse = GrpcLectureExtension.AsBase(createdVoteModel.Lecture);
        LectureVote createdLectureVote = new LectureVote(userFromResponse, lectureFromResponse, createdVoteModel.Upvote);
        return createdLectureVote;
    }

    public async Task<LectureVoteCounter> GetLectureVotesCountAsync(Lecture lecture)
    {
        LectureModel lectureModel = GrpcLectureExtension.AsGrpcModel(lecture);
        VoteCounter voteCounter = await _lectureVoteGrpcClient.GetLectureVotesCountAsync(lectureModel);
        Lecture lectureFromResponse = GrpcLectureExtension.AsBase(voteCounter.Lecture);
        LectureVoteCounter lectureVoteCounter = new LectureVoteCounter(lectureFromResponse, voteCounter.UpvoteCount, voteCounter.DownvoteCount);
        return lectureVoteCounter;
    }

    public async Task<LectureVote> GetLectureVotebyIdAsync(User user, Lecture lecture)
    {
        VoteId model = new VoteId();
        model.Lecture = GrpcLectureExtension.AsGrpcModel(lecture);
        model.User = GrpcUserExtension.AsGrpcModel(user);
        VoteModel createdVoteModel = await _lectureVoteGrpcClient.GetVoteByIdAsync(model);
        User userFromResponse = GrpcUserExtension.AsBase(createdVoteModel.User);
        Lecture lectureFromResponse = GrpcLectureExtension.AsBase(createdVoteModel.Lecture);
        LectureVote createdLectureVote = new LectureVote(userFromResponse, lectureFromResponse, createdVoteModel.Upvote);
        return createdLectureVote;
    }
}