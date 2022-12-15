using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface IAnswerService
{
    Task<Answer> CreateAsync(Answer answerAppended);
    Task<Answer?> GetAnswerById(long id);
    Task DeleteAnswerAsync(Answer answer);
    Task<List<Answer>> GetAllAnswersByQuestionId(long id);
}