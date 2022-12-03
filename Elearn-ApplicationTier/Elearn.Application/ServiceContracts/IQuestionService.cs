using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface IQuestionService
{
    Task<List<Question>> GetAllQuestionsAsync();

    Task<Question?> GetQuestionByUrlAsync(string url);

    Task<Question> CreateNewQuestionAsync(Question question);
    Task<List<Question>> GetQuestionByUserIdAsync(int userId);
    Task<List<Question>> GetAllQuestionsAsync(int pageNumber, int pageSize);
}