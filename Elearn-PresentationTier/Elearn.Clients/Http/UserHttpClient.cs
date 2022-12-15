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


    public async Task<UserDto> GetUserByUsernameAsync(string? username)
    {
        HttpResponseMessage response = await client.GetAsync($"Users/{username}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        UserDto userDto = JsonSerializer.Deserialize<UserDto>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return userDto;
    }

    public async Task UpdateUserAsync(UpdateUserDto dto)
    {
        Console.WriteLine(dto);
        string dtoAsJson = JsonSerializer.Serialize(dto);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PatchAsync("/Users", body);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
    }

    public async Task<List<UserDto>> GetUsersAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/Users");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        List<UserDto> usersDtos = JsonSerializer.Deserialize<List<UserDto>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return usersDtos;
    }

    public async Task DeleteUserAsync(string username)
    {
        HttpResponseMessage response = await client.DeleteAsync($"Users/{username}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<UserDto> GetUserByNameAsync(string? name)
    {
        HttpResponseMessage response = await client.GetAsync($"/Users/user/{name}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        UserDto userDto = JsonSerializer.Deserialize<UserDto>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return userDto;
    }
}