using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface ICommentService
{
    Task<Comment> CreateAsync(Comment comment);
    Task<List<Comment>> GetAllCommentsByLectureId(long id);
    Task<Comment?> GetCommentById(long id);
    Task DeleteCommentAsync(Comment comment);
}