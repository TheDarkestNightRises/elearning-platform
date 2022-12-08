

using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface ICommentLogic
{
    Task<Comment> CreateAsync(Comment comment);
    
    Task<IEnumerable<Comment>> GetAsync(SearchCommentParametersDto searchParameters);
    
    Task DeleteAsync(int id);
    Task<List<Comment>> GetAllCommentsByLectureId(long id);
    Task DeleteCommentAsync(long id);
}