using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.HttpClients.Service;

public interface ICommentService 
{
    Task<CommentDto> Create(CommentCreationDto dto);


    Task<List<CommentUserDto?>> GetAllCommentsByLectureId(long id);
}