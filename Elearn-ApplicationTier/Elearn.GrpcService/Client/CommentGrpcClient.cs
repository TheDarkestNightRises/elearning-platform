﻿using Elearn.Application.ServiceContracts;
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

    public IQueryable<Comment> GetAllCommentsByPostUrlAsync(string url)
    {
        throw new NotImplementedException();
    }
}