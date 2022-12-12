using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface IQuestionService
{
    Task<List<Question>> GetAllQuestionsAsync();

    Task<Question?> GetQuestionByUrlAsync(string url);

    Task<Question> CreateNewQuestionAsync(Question question);
    Task<List<Question>> GetQuestionByUserIdAsync(long userId);
    Task<List<Question>> GetAllQuestionsAsync(int pageNumber, int pageSize);
    Task DeleteQuestionAsync(Question questionToDelete);
    Task<Question> EditQuestionAsync(Question question);

}