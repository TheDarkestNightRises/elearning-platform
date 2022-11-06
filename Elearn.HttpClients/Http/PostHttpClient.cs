using System.Net.Http.Json;
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
    public async Task CreateAsync(PostCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/posts",dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
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