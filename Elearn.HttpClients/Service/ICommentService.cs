using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.BlazorWASM;

public interface ICommentService
{
    Task<Comment> Create(CommentCreationDto dto);
}