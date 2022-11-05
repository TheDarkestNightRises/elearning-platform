using Elearn.Application.RepositoryInterfaces;
using Elearn.Data.Data;
using Elearn.Shared.Models;

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
}