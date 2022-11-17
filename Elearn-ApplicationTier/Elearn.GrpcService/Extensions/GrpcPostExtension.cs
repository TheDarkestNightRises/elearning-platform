using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using ElearnGrpc;
using Google.Protobuf.WellKnownTypes;

namespace Elearn.GrpcService.Extensions;

public static class GrpcPostExtension
{
    public static PostModel AsGrpcModel(this Post post)
    {
        return new PostModel
        {
            Id = post.Id,
            Url = post.Url,
            Image = post.Image,
            Title = post.Title,
            Body = post.Body
        };
    }

    public static Post AsBase(this PostModel postModel)
    {
        return new Post
        {
            Id = postModel.Id,
            Url = postModel.Url,
            Image = postModel.Image,
            Title = postModel.Title,
            Body = postModel.Body
        };
    }
}

