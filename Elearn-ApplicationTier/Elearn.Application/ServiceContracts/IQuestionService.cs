using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface IQuestionService
{
    Task<List<Question>> GetAllQuestionsAsync();

    Task<Question?> GetQuestionByUrlAsync(string url);

    Task<Question> CreateNewQuestionAsync(Question question);

    Task<Question?> GetQuestionByIdAsync(int id);
}