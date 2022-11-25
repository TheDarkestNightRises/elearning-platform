using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Models;

namespace Elearn.Application.Logic;

public class SearchLogic : ISearchLogic
{
    private ISearchLogic _searchLogic;
    
    public SearchLogic(ISearchLogic searchLogic)
    {
        _searchLogic = searchLogic;
    }
    
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