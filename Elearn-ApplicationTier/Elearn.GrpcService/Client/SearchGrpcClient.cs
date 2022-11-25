using Elearn.Application.ServiceContracts;
using Elearn.Shared.Models;

namespace Elearn.GrpcService.Client;

public class SearchGrpcClient : ISearchService
{
    public Task<List<User>> SearchUsersAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<List<Lecture>> SearchLecturesAsync(string title)
    {
        throw new NotImplementedException();
    }

    public Task<List<Question>> SearchQuestionsAsync(string title)
    {
        throw new NotImplementedException();
    }
}