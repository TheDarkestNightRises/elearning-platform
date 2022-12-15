using Elearn.Shared.Dtos;

namespace Elearn.HttpClients.Service;

public interface IAnswerService
{
    Task<AnswerDto> Create(AnswerCreationDto dto);
    
    Task DeleteAnswerAsync(long id);
    
    Task<List<AnswerUserDto?>> GetAllAnswersByQuestionId(long id);
}