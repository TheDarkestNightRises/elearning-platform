using System.Net.Http.Json;
using System.Text.Json;
using Elearn.HttpClients.Service;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Clients.Http;


public class QuestionHttpClient : IQuestionService
{
    private readonly HttpClient client;
    
    public QuestionHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("Questions");
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

    public async Task<QuestionDto> GetQuestionByUrlAsync(string url)
    {
        HttpResponseMessage response = await client.GetAsync($"Questions/{url}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        QuestionDto _questionDto = JsonSerializer.Deserialize<QuestionDto>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return _questionDto;
    }

    public async Task<List<QuestionDto?>> GetQuestionByUserIdAsync(long userId)
    {
        HttpResponseMessage response = await client.GetAsync($"/Users/{userId}/questions");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
        return await response.Content.ReadFromJsonAsync<List<QuestionDto?>>();
    }
}