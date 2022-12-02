using Elearn.Application.LogicInterfaces;
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
}