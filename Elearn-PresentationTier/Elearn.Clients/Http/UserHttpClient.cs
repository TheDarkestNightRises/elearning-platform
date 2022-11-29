using System.Text;
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
    
  

    public async Task<User> GetUserByUsernameAsync(string? username)
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

    public async Task UpdateUserAsync(UpdateUserDto dto)
    {
        Console.WriteLine(dto);
        string dtoAsJson = JsonSerializer.Serialize(dto);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PatchAsync("/user", body);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        

        
    }
}