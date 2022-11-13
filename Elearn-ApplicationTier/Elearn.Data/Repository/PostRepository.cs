using Elearn.Application.RepositoryContracts;
using Elearn.Data.Data;
using Elearn.Shared.Models;
using Microsoft.EntityFrameworkCore;

    
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
        await _dataContext.AddAsync(post);
        await _dataContext.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> GetByIdAsync(int dtoPostId)
    {
        return await _dataContext.Posts.FirstOrDefaultAsync(p => p.Id.Equals(dtoPostId));
    }
}

