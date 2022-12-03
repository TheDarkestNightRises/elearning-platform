using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface ILectureLogic
{
    Task<Lecture> CreateAsync(Lecture lecture);
    Task<List<Lecture>> GetAllLecturesAsync();
    Task<Lecture?> GetLectureAsync(string url);
    Task<List<Lecture>> GetLectureByTeacherIdAsync(long userId);
    Task<List<Lecture>> GetUpvotedLectureByUserIdAsync(long userId);
    Task<List<Lecture>> GetLecturesByUniversityAsync(University university);
    Task<List<Lecture>> GetAllLecturesAsync(int pageNumber, int pageSize);
}