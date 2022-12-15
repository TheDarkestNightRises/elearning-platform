using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Models;

namespace Elearn.Application.Logic;

public class UniversityLogic : IUniversityLogic
{
    private readonly IUniversityService _universityService;

    public UniversityLogic(IUniversityService universityService)
    {
        _universityService = universityService;
    }

    public async Task<List<University>> GetAllUniversitiesAsync()
    {
        return await _universityService.GetAllUniversitiesAsync();
    }

    public async Task<University> GetUniversitybyIdAsync(long id)
    {
        University university = await _universityService.GetUniversityByIdAsync(id);
        if (university is null)
        {
            throw new Exception("No university found with this id");
        }

        return university;
    }
}