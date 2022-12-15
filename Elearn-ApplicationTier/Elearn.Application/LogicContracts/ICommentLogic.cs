

using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface ICommentLogic
{
    Task<Comment> CreateAsync(Comment comment);
    
    Task<List<Comment>> GetAllCommentsByLectureId(long id);
    Task DeleteCommentAsync(long id);
}