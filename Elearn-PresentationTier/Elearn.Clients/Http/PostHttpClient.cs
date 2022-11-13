using System.Net.Http.Json;
using System.Text.Json;
using Elearn.HttpClients.Service;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;


namespace Elearn.HttpClients.Http;

public class PostHttpClient : IPostService
{
    
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }
    public async Task<PostDto> CreateAsync(PostCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/posts",dto);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            
            throw new Exception(content);
        }
        PostDto postDto = JsonSerializer.Deserialize<PostDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return postDto;
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        return await client.GetFromJsonAsync<List<Post>>("/posts");
    }

    public async Task<Post?> GetPostByUrlAsync(string url)
    {
        HttpResponseMessage response = await client.GetAsync($"/posts/{url}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
        return await response.Content.ReadFromJsonAsync<Post>();
    }
}