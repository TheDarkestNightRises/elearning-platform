using Elearn.Application.ServiceContracts;
using Elearn.Shared.Models;

namespace Elearn.GrpcService.Client;

public class PostGrpcClient : IPostService
{
    public Task<List<Post>> GetAllPostsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetPostAsync(string url)
    {
        throw new NotImplementedException();
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