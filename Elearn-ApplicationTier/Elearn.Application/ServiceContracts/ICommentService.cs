using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface ICommentService
{
    Task<Comment> CreateAsync(Comment comment);
    IQueryable<Comment> GetAllCommentsByPostUrlAsync(string url);
}