using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface ICountryLogic
{
    Task<List<Country>> GetAllCountriesAsync();
    Task<Country> GetCountryByIdAsync(long id);
}