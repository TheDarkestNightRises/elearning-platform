
using Shared.Dtos;
using Shared.Models;

namespace Blog.BlazorWASM;

public interface ICommentService
{
    Task<Comment> Create(CommentCreationDto dto);
}