using Elearn.Shared.Dtos;

namespace Elearn.HttpClients.Service;

public interface IQuestionService
{ 
    Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync();
}