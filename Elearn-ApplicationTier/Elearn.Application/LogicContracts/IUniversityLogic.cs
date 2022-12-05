using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface IUniversityLogic
{
    Task<List<University>> GetAllUniversitiesAsync();
    Task<University> GetUniversitybyIdAsync(long id);
}