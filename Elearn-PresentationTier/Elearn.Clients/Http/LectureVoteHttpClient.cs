using System.Net.Http.Json;
using System.Text.Json;
using Elearn.HttpClients.Service;
using Elearn.Shared.Dtos;

namespace Elearn.Clients.Http;

public class LectureVoteHttpClient : ILectureVoteService
{
    private readonly HttpClient client;

    public LectureVoteHttpClient(HttpClient client)
    {
        this.client = client;
    }
    public async Task<LectureVoteDto> CreateAsync(LectureVoteDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/LectureVote",dto);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            
            throw new Exception(content);
        }
        LectureVoteDto lectureVoteDto = JsonSerializer.Deserialize<LectureVoteDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return lectureVoteDto;
    }

    public async Task<LectureVoteDto> GetByIdAsync(string username, string url)
    {
        HttpResponseMessage response = await client.GetAsync($"/LectureVote/?username={username}&url={url}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
        return await response.Content.ReadFromJsonAsync<LectureVoteDto>();
    }

    public async Task<LectureVoteCounterDto> GetVoteCounter(string url)
    {
        HttpResponseMessage response = await client.GetAsync($"/LectureVote/{url}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
        return await response.Content.ReadFromJsonAsync<LectureVoteCounterDto>();
    }
}