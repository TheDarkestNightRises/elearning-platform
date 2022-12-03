using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface IQuestionLogic
{
    Task<Question> CreateQuestionAsync(Question question);
    Task<Question> GetQuestionByUrlAsync(string url);
    Task<List<Question>> GetQuestionsAsync();
    Task<List<Question>> GetQuestionByUserIdAsync(int userId);
    Task<List<Question>> GetQuestionsAsync(int pageNumber, int pageSize);
}