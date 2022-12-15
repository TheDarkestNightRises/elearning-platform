using Elearn.Shared.Dtos;

namespace Elearn.HttpClients.Service;

public interface ICountryService
{
    Task<List<CountryDto>> GetAllCountriesAsync();
    Task<CountryDto> GetCountryByIdAsync(long id);
}