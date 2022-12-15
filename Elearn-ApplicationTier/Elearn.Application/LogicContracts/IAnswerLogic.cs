using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface IAnswerLogic
{
    Task<Answer> CreateAsync(Answer answer);
    Task DeleteAnswerAsync(long id);

    Task<List<Answer>> GetAllAnswersByQuestionId(long id);
}