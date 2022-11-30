using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface IUniversityService
{
    Task<List<Lecture>> GetAllLecturesByUniversity(University university);
    Task<List<University>> GetAllUniversities();
}