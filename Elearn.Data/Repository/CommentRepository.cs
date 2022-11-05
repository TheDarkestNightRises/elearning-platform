using Elearn.Application.RepositoryInterfaces;
using Elearn.Data.Data;
using Shared.Models;

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
        _dataContext.Add(comment);
        await _dataContext.SaveChangesAsync();
        return comment;
    }
}