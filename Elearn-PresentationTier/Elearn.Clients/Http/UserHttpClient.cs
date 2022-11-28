using System.Text.Json;
using Elearn.HttpClients.Service;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Clients.Http;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;
    
    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
  

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        HttpResponseMessage response = await client.GetAsync($"user/{username}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }

    public async Task UpdateUserAsync(UpdateUserDto updateUser)
    {
        HttpResponseMessage response = await client.GetAsync($"/user");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
    }
}