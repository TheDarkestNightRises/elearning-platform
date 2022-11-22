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
        model.Post = GrpcPostExtension.AsGrpcModel(lectureVote.Post);
        model.User = GrpcUserExtension.AsGrpcModel(lectureVote.User);
        model.Upvote = lectureVote.Upvote;
        VoteModel createdVoteModel = await _lectureVoteGrpcClient.VoteLectureAsync(model);
        User userFromResponse = GrpcUserExtension.AsBase(createdVoteModel.User);
        Post postFromResponse = GrpcPostExtension.AsBase(createdVoteModel.Post);
        LectureVote createdLectureVote = new LectureVote(userFromResponse, postFromResponse, createdVoteModel.Upvote);
        return createdLectureVote;
    }

    public async Task<LectureVoteCounter> GetLectureVotesCountAsync(Post post)
    {
        PostModel postModel = GrpcPostExtension.AsGrpcModel(post);
        VoteCounter voteCounter = await _lectureVoteGrpcClient.GetLectureVotesCountAsync(postModel);
        Post postFromResponse = GrpcPostExtension.AsBase(voteCounter.Post);
        LectureVoteCounter lectureVoteCounter = new LectureVoteCounter(postFromResponse, voteCounter.UpvoteCount, voteCounter.DownvoteCount);
        return lectureVoteCounter;
    }

    public async Task<LectureVote> GetLectureVotebyIdAsync(User user, Post post)
    {
        VoteId model = new VoteId();
        model.Post = GrpcPostExtension.AsGrpcModel(post);
        model.User = GrpcUserExtension.AsGrpcModel(user);
        VoteModel createdVoteModel = await _lectureVoteGrpcClient.GetVoteByIdAsync(model);
        User userFromResponse = GrpcUserExtension.AsBase(createdVoteModel.User);
        Post postFromResponse = GrpcPostExtension.AsBase(createdVoteModel.Post);
        LectureVote createdLectureVote = new LectureVote(userFromResponse, postFromResponse, createdVoteModel.Upvote);
        return createdLectureVote;
    }
}