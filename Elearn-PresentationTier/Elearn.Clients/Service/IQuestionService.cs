using Elearn.Shared.Dtos;

namespace Elearn.HttpClients.Service;

public interface IQuestionService
{ 
    Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync();
    Task<QuestionDto> GetQuestionByUrlAsync(string url);
    Task<List<QuestionDto>> GetQuestionByUserIdAsync(long userId);

}