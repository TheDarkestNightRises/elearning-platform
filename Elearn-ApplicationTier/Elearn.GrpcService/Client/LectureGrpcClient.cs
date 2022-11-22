using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Extensions;
using Elearn.Shared.Models;
using ElearnGrpc;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;

namespace Elearn.GrpcService.Client;

public class LectureGrpcClient : ILectureService
{
    private PostService.PostServiceClient _postClient;

    public LectureGrpcClient()
    {
        var _grpcChannel =
            new Channel("localhost:8843", ChannelCredentials.Insecure);
        _postClient = new PostService.PostServiceClient(_grpcChannel);
    }

    public async Task<List<Lecture>> GetAllPostsAsync()
    {
        List<Lecture> posts = new List<Lecture>();
        using (var call = _postClient.GetAllPost(new NewPostRequest()))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentPost = call.ResponseStream.Current;
                posts.Add(currentPost.AsBase());
            }
        }
        return posts;
    }

    public async Task<Lecture?> GetPostAsync(string url)
    {
        var postRequested = new PostUrl { Url = url };
        var postFromGrpc = await _postClient.GetPostAsync(postRequested);
        return postFromGrpc.AsBase();
    }

    public async Task<Lecture> CreateNewPostAsync(Lecture lecture)
    {
        var postModel = post.AsGrpcModel();
        //Append user to post
        var userModel = post.Author.AsGrpcModel();
        postModel.User = userModel;
        var createdPostFromGrpc = await _postClient.CreateNewPostAsync(postModel);
        return createdPostFromGrpc.AsBase();
    }
    
    public async Task<Lecture?> GetByIdAsync(int id)
    {
        var postRequested = new PostId { Id = dtoPostId };
        var postFromGrpc = await _postClient.GetByIdAsync(postRequested);
        return postFromGrpc.AsBase();    
    }
}