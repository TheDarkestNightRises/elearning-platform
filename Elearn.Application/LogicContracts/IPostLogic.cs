using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto post);
    Task<List<Post>> GetAllPostsAsync();
    Task<Post?> GetPostAsync(string url);
}