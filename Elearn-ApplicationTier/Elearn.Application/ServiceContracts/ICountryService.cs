using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface ICountryService
{
    Task<List<Country>> GetAllCountriesAsync();
    Task<Country> GetCountryByIdAsync(long id);
}