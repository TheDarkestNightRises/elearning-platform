using Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(Post post);
    Task<List<Post>> GetAllPostsAsync();
    Task<Post?> GetPostAsync(string url);
}