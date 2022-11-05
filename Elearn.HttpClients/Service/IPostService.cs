
using Shared;
using Shared.Models;

namespace Blog.BlazorWASM;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<List<Post>> GetPostsAsync();
    Task<Post?> GetPostByUrlAsync(string url);
}