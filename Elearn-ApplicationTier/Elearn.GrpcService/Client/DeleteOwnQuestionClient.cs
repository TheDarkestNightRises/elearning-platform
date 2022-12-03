using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.GrpcService.Client;

public class DeleteOwnQuestionClient : IDeleteOwnQuestionLogic
{
    public Task<Question> DeleteOwnQuestionAsync(Question question)
    {
        throw new NotImplementedException();
    }
    
    public IQueryable<Question>DeleteOwnQuestion(Question question)
    {
        throw new NotImplementedException();
    }

    public async Task<DeleteOwnQuestion> DeleteOwnQuestionAsync(DeleteOwnQuestion deleteOwnQuestion)

    {
        throw new NotImplementedException();
    }

    public async Task<List<Question>> DeleteOwnQuestionAsync(List<DeleteOwnQuestion> deleteOwnQuestion)

    {
        throw new NotImplementedException();
    }

    public async Task<Question?> DeleteOwnQuestionAsync(int questionId)

    {
        throw new NotImplementedException();
    }

    public async Task<Question?> DeleteOwnQuestion(DeleteOwnQuestionDto deleteOwnQuestionDto)

    {
        throw new NotImplementedException();
    }
}