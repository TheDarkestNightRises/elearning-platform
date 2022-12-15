using System.Net.Http.Json;
using System.Text.Json;
using Elearn.HttpClients.Service;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Clients.Http;

public class CommentHttpClient : ICommentService
{
    private readonly HttpClient client;

    public CommentHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<CommentDto> Create(CommentCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Comments", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        CommentDto comment = JsonSerializer.Deserialize<CommentDto>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return comment;
    }

    public async Task DeleteCommentAsync(long id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"Comments/{id}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<List<CommentUserDto?>> GetAllCommentsByLectureId(long id)
    {
        HttpResponseMessage response = await client.GetAsync($"/Comments/Lecture/{id}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
        return await response.Content.ReadFromJsonAsync<List<CommentUserDto?>>();
    }
    
}