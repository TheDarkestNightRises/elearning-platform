using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface IPostService
{
    Task<List<Post>> GetAllPostsAsync();
    Task<Post?> GetPostAsync(string url);
    Task<Post> CreateNewPostAsync(Post post);
    Task<Post?> GetByIdAsync(int dtoPostId);
}
