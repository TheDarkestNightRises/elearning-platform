using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.HttpClients.Service;

public interface ISearchService
{
    Task<List<UserDto>> SearchUsersAsync (string username);
    Task<List<LectureDto>> SearchLecturesAsync (string title);
    Task<List<QuestionDto>> SearchQuestionsAsync (string title);
}