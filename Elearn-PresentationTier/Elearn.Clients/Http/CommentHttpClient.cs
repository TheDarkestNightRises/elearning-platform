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

    public async Task<List<CommentDto>> GetCommentsByPostUrlAsync(string url)
    {
        //Todo: Refactor this so it fits with dtos
        return await client.GetFromJsonAsync<List<CommentDto>>($"/Comments/{url}");
    }
    
}