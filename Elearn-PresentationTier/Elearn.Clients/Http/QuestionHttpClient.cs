using System.Net.Http.Json;
using System.Text;
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
    
    public async Task<List<QuestionDto>> GetAllQuestionsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("Questions");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        List<QuestionDto> questionDtos = JsonSerializer.Deserialize<List<QuestionDto>>(result, new JsonSerializerOptions
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

    public async Task<List<QuestionDto>> GetQuestionByUserIdAsync(long userId)
    {
        HttpResponseMessage response = await client.GetAsync($"/Users/{userId}/questions");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
        return await response.Content.ReadFromJsonAsync<List<QuestionDto>>();
    }

    public async Task<QuestionDto> CreateAsync(QuestionCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Questions", dto);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        QuestionDto questionDto = JsonSerializer.Deserialize<QuestionDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return questionDto;
    }

    public async Task UpdateQuestionAsync(QuestionUpdateDto dto)
    {
        string dtoAsJson = JsonSerializer.Serialize(dto);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PatchAsync("/Questions", body);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
    }

    public async Task DeleteLectureAsync(string url)
    {
        HttpResponseMessage response = await client.DeleteAsync($"Questions/{url}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
}