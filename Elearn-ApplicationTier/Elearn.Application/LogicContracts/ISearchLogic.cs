using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface ISearchLogic
{
    Task<List<User>> SearchUsersAsync (string username);
    Task<List<Lecture>> SearchLecturesAsync (string title);
    Task<List<Question>> SearchQuestionsAsync (string title);
}