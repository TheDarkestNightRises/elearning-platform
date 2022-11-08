using Elearn.Application.RepositoryContracts;
using Elearn.Data.Data;
using Elearn.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Data.Repository;

public class CommentRepository : ICommentRepository
{
    private DataContext _dataContext;

    public CommentRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<Comment> CreateAsync(Comment comment)
    {
        await _dataContext.AddAsync(comment);
        await _dataContext.SaveChangesAsync();
        return comment;
    }

    public IQueryable<Comment> GetAllCommentsByPostUrlAsync(string url)
    {
        return _dataContext.Comments.Where(c => c.Post.Url.Equals(url));
    }
}