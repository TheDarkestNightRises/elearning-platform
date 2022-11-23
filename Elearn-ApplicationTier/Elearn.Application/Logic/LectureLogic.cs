using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;


namespace Elearn.Application.Logic;

public class LectureLogic : ILectureLogic
{
    private readonly ILectureService _lectureService;
    private readonly IUserService _userService;

    public LectureLogic(ILectureService lectureService, IUserService userService)
    {
        _lectureService = lectureService;
        _userService = userService;
    }

    public async Task<Lecture> CreateAsync(Lecture lecture)
    {
        //TODO: validate user when login part done
        //TODO: validate unique url
        //ValidateCreationDto(dto);
        User? user = await _userService.GetUserByNameAsync(lecture.Author.Username);
        if (user is null)
        {
            throw new Exception("User not found in database");
        }
        Lecture lectureAppended = new Lecture(lecture.Title, lecture.Body, lecture.Url, lecture.Image,user);
        Lecture created = await _lectureService.CreateNewPostAsync(lectureAppended);
        return created;
    }

    public async Task<List<Lecture>> GetAllLecturesAsync()
    {
        return await _lectureService.GetAllPostsAsync();
    }

    public async Task<Lecture?> GetLectureAsync(string url)
    {
        return await _lectureService.GetPostAsync(url);
    }

    private void ValidateCreation(Lecture lecture)
    {
        if (string.IsNullOrEmpty(lecture.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(lecture.Body)) throw new Exception("Lecture body cannot be empty.");
        if (string.IsNullOrEmpty(lecture.Url)) throw new Exception("Url cannot be empty.");
    }
}