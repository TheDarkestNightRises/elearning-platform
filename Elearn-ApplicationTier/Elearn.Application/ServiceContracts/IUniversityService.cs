using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface IUniversityService
{
    Task<List<Lecture>> GetAllLecturesByUniversityAsync(University university);
    Task<List<University>> GetAllUniversitiesAsync();
    Task<University> GetUniversityByIdAsync(long id);
}