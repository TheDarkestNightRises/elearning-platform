
using Shared.Dtos;
using Shared.Models;

namespace Elearn.BlazorWASM;

public interface ICommentService
{
    Task<Comment> Create(CommentCreationDto dto);
}