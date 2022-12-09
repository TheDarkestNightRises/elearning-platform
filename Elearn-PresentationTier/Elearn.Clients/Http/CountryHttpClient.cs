using System.Net.Http.Json;
using System.Text.Json;
using Elearn.HttpClients.Service;
using Elearn.Shared.Dtos;

namespace Elearn.Clients.Http;

public class CountryHttpClient : ICountryService
{
    private readonly HttpClient client;

    public CountryHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<List<CountryDto>> GetAllCountriesAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/Countries");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        List<CountryDto> countryDtos = JsonSerializer.Deserialize<List<CountryDto>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return countryDtos;
    }

    public async Task<CountryDto> GetCountryByIdAsync(long id)
    {
        HttpResponseMessage response = await client.GetAsync($"/Countries/{id}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }

        return await response.Content.ReadFromJsonAsync<CountryDto>();
    }
}