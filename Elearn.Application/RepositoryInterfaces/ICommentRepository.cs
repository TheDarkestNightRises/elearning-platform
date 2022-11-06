using Elearn.Shared.Models;

namespace Elearn.Application.RepositoryInterfaces;

public interface ICommentRepository
{
    Task<Comment> CreateAsync(Comment comment);
    IQueryable<Comment> GetAllCommentsByPostUrlAsync(string url);
}