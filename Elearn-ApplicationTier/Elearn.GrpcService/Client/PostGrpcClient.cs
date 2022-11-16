using Elearn.Application.ServiceContracts;
using Elearn.Shared.Models;
using ElearnGrpc;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;

namespace Elearn.GrpcService.Client;

public class PostGrpcClient : IPostService
{
    private ElearnGrpc.PostService.PostServiceClient _postClient;

    public PostGrpcClient()
    {
        // var httpHandler = new HttpClientHandler();
        // httpHandler.ServerCertificateCustomValidationCallback =
        //     HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        // var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));

        var _grpcChannel =
            new Channel("localhost:8843", ChannelCredentials.Insecure);
        _postClient = new PostService.PostServiceClient(_grpcChannel);
    }

    public Task<List<Post>> GetAllPostsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Post?> GetPostAsync(string url)
    {
        var postRequested = new PostLookupModel { Url = url };
        var postFromGrpc = _postClient.GetPost(postRequested);
        Post post = new Post
        {
            Id = postFromGrpc.Id,
            Body = postFromGrpc.Body,
            Title = postFromGrpc.Title
        };
        return post;
    }

    public Task<Post> CreateNewPostAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetByIdAsync(int dtoPostId)
    {
        throw new NotImplementedException();
    }
}