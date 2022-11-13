using Elearn.Shared.Models;

namespace Elearn.Application.RepositoryContracts;

public interface IPostRepository
{
    Task<List<Post>> GetAllPostsAsync();
    Task<Post?> GetPostAsync(string url);
    Task<Post> CreateNewPostAsync(Post post);
    Task<Post?> GetByIdAsync(int dtoPostId);
}
