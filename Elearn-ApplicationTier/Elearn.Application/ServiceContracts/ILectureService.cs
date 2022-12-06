using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface ILectureService
{
    Task<List<Lecture>> GetAllLecturesAsync();
    Task<Lecture?> GetPostAsync(string url);
    Task<Lecture> CreateNewPostAsync(Lecture lecture);
    Task<Lecture?> GetByIdAsync(long id);
    Task<List<Lecture>> GetLectureByTeacherIdAsync(long userId);
    Task<List<Lecture>> GetUpvotedLectureByUserIdAsync(long userId);
    Task<List<Lecture>> GetAllLecturesAsync(int pageNumber, int pageSize);
}