using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Models;

namespace Elearn.Application.Logic;

public class SearchLogic : ISearchLogic
{
    private readonly ISearchService _searchService;

    public SearchLogic(ISearchService searchService)
    {
        _searchService = searchService;
    }

    public async Task<List<User>> SearchUsersAsync(string username)
    {
        var users = await _searchService.SearchUsersAsync(username);
        return users;
    }

    public async Task<List<Lecture>> SearchLecturesAsync(string title)
    {
        var lectures = await _searchService.SearchLecturesAsync(title);
        return lectures;
    }

    public async Task<List<Question>> SearchQuestionsAsync(string title)
    {
        var questions = await _searchService.SearchQuestionsAsync(title);
        return questions;
    }
}