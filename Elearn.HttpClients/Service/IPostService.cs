

using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.HttpClients.Service;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<List<Post>> GetPostsAsync();
    Task<Post?> GetPostByUrlAsync(string url);
}