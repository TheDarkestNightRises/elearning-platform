using System.Net.Http.Json;
using System.Text.Json;
using Elearn.HttpClients.Service;
using Elearn.Shared.Dtos;

namespace Elearn.Clients.Http;

public class UniversityHttpClient : IUniversityService
{
    private readonly HttpClient client;

    public UniversityHttpClient(HttpClient client)
    {
        this.client = client;
    }
    public async Task<List<UniversityDto>> GetAllUniveritiesAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/Universities");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        List<UniversityDto> universityDtos = JsonSerializer.Deserialize<List<UniversityDto>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return universityDtos;
    }

    public async Task<UniversityDto> GetUniversityByIdAsync(long id)
    {
        HttpResponseMessage response = await client.GetAsync($"/Universities/{id}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }

        return await response.Content.ReadFromJsonAsync<UniversityDto>();
    }
}