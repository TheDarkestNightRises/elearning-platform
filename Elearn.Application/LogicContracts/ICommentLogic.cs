

using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface ICommentLogic
{
    Task<Comment> CreateAsync(CommentCreationDto dto);
    
    Task<IEnumerable<Comment>> GetAsync(SearchCommentParametersDto searchParameters);
    
    Task DeleteAsync(int id);
}