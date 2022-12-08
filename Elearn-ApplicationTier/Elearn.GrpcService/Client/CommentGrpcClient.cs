using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Extensions;
using Elearn.Shared.Models;
using ElearnGrpc;
using Grpc.Core;

namespace Elearn.GrpcService.Client;

public class CommentGrpcClient : ICommentService
{
    private CommentService.CommentServiceClient _commentClient;

    public CommentGrpcClient()
    {
        var _grpcChannel =
            new Channel("localhost:8843", ChannelCredentials.Insecure);
        _commentClient = new CommentService.CommentServiceClient(_grpcChannel);
    }

    public async Task<Comment> CreateAsync(Comment comment)
    {
        var commentModel = comment.AsGrpcModel();
        var createdCommentFromGrpc = await _commentClient.CreateNewCommentAsync(commentModel);
        Comment createdComment = createdCommentFromGrpc.AsBase();
        return createdComment;
    }

    public async Task<List<Comment>> GetAllCommentsByLectureId(long id)
    {
        List<Comment> comments = new List<Comment>();
        var request = new LectureId() { Id = id };
        using (var call = _commentClient.GetCommentByLectureId(new LectureId(request)))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentComment = call.ResponseStream.Current;
                comments.Add(currentComment.AsBase());
            }
        }

        return comments;
    }

    public async Task<Comment?> GetCommentById(long id)
    {
        var commentRequested = new CommentId {  Id = id};
        var commentFromGrpc = await _commentClient.GetCommentByIdAsync(commentRequested);
        return commentFromGrpc.AsBase();
    }

    public async Task DeleteCommentAsync(Comment comment)
    {
        var commentModel = comment.AsGrpcModel();
        await _commentClient.DeleteCommentAsync(commentModel);
    }
}