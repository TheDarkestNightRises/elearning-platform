using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface IDeleteOwnQuestionLogic
{
    public Task<DeleteOwnQuestion> DeleteOwnQuestionAsync(DeleteOwnQuestion deleteOwnQuestion);
    public Task<List<Question>> DeleteOwnQuestionAsync(List<DeleteOwnQuestion> deleteOwnQuestion);
    public Task<Question?> DeleteOwnQuestionAsync(int questionId);
    Task<Question?>DeleteOwnQuestion(DeleteOwnQuestionDto deleteOwnQuestionDto);
}