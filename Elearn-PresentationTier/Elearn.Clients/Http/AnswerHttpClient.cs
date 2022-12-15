using System.Net.Http.Json;
using System.Text.Json;
using Elearn.HttpClients.Service;
using Elearn.Shared.Dtos;

namespace Elearn.Clients.Http;

public class AnswerHttpClient : IAnswerService
{
    private readonly HttpClient client;

    public AnswerHttpClient(HttpClient client)
    {
        this.client = client;
    }

    
    public async Task<AnswerDto> Create(AnswerCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Answers", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        AnswerDto answer = JsonSerializer.Deserialize<AnswerDto>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return answer;
    }

    public async Task DeleteAnswerAsync(long id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"Answers/{id}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<List<AnswerUserDto?>> GetAllAnswersByQuestionId(long id)
    {
        HttpResponseMessage response = await client.GetAsync($"/Answers/Question/{id}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
        return await response.Content.ReadFromJsonAsync<List<AnswerUserDto?>>();
    }
}