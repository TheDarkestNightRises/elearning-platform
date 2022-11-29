using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface ILectureService
{
    Task<List<Lecture>> GetAllPostsAsync();
    Task<Lecture?> GetPostAsync(string url);
    Task<Lecture> CreateNewPostAsync(Lecture lecture);
    Task<Lecture?> GetByIdAsync(int id);
    Task<List<Lecture>> GetLectureByUserIdAsync(long userId);
    Task<List<Lecture>> GetUpvotedLectureByUserIdAsync(long userId);


}
