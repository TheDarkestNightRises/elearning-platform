using System.Text.Json;
using Elearn.HttpClients.Service;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Clients.Http;


public class QuestionHttpClient : IQuestionService
{
    private readonly HttpClient client;
    
    public async Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("questions");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<QuestionDto> questionDtos = JsonSerializer.Deserialize<IEnumerable<QuestionDto>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return questionDtos;
    }
}