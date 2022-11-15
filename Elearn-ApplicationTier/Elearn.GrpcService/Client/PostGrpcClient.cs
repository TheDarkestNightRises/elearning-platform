using Elearn.Application.ServiceContracts;
using ElearnGrpc;
using Grpc.Net.Client;
using Post = Elearn.Shared.Models.Post;

namespace Elearn.GrpcService.Client;

public class PostGrpcClient : IPostService
{
    private GrpcChannel _grpcChannel;
    private ElearnGrpc.Post.PostClient _postClient;

    public PostGrpcClient()
    {
        _grpcChannel = GrpcChannel.ForAddress("https://localhost:7261");
        _postClient = new ElearnGrpc.Post.PostClient(_grpcChannel);
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