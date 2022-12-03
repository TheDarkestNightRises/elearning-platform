using System.Text.Json;
using Elearn.HttpClients.Service;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Clients.Http;

public class SearchHttpClient : ISearchService
{
    private readonly HttpClient client;

    public SearchHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<List<UserDto>> SearchUsersAsync(string username)
    {
        HttpResponseMessage response = await client.GetAsync($"Search/users/{username}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        List<UserDto> userDtos = JsonSerializer.Deserialize<List<UserDto>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return userDtos;
    }

    public async Task<List<LectureDto>> SearchLecturesAsync(string title)
    {
        HttpResponseMessage response = await client.GetAsync($"Search/lectures/{title}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        List<LectureDto> lectureDtos = JsonSerializer.Deserialize<List<LectureDto>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return lectureDtos;
    }

    public async Task<List<QuestionDto>> SearchQuestionsAsync(string title)
    {
        HttpResponseMessage response = await client.GetAsync($"Search/questions/{title}");
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
}