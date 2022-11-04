using Elearn.Application.RepositoryInterfaces;
using Elearn.Data.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

    
namespace Elearn.Data.Repository;

public class PostRepository : IPostRepository
{
    private DataContext _dataContext;

    public PostRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await _dataContext.Posts.ToListAsync();
    }

    public async Task<Post?> GetPostAsync(string url) 
    {
        return await _dataContext.Posts.FirstOrDefaultAsync(p => p.Url.Equals(url));
    }

    public async Task<Post> CreateNewPostAsync(Post post)
    {
        _dataContext.Add(post);
        await _dataContext.SaveChangesAsync();
        return post;
    }
}

