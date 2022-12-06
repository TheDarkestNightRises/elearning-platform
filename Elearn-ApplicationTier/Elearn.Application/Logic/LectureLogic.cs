using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;


namespace Elearn.Application.Logic;

public class LectureLogic : ILectureLogic
{
    private readonly ILectureService _lectureService;
    private readonly IUniversityService _universityService;
    private readonly ITeacherService _teacherService;

    public LectureLogic(ILectureService lectureService, IUniversityService universityService, ITeacherService teacherService)
    {
        _lectureService = lectureService;
        _universityService = universityService;
        _teacherService = teacherService;
    }

    public async Task<Lecture> CreateAsync(Lecture lecture)
    {
        //TODO: validate user when login part done
        //TODO: validate unique url
        //ValidateCreationDto(dto);
       
        Teacher teacher = await _teacherService.GetTeacherByUsernameAsync(lecture.Author.Username);
        
        if (teacher is null)
        {
            throw new Exception("Teacher not found in database");
        }
        Lecture lectureAppended = new Lecture(lecture.Title, lecture.Body, lecture.Url, lecture.Image,lecture.Description, teacher);
        Lecture created = await _lectureService.CreateNewPostAsync(lectureAppended);
        return created;
    }

    public async Task<List<Lecture>> GetAllLecturesAsync()
    {
        return await _lectureService.GetAllLecturesAsync();
    }

    public async Task<Lecture?> GetLectureAsync(string url)
    {
        return await _lectureService.GetPostAsync(url);
    }

    public async Task<List<Lecture>> GetLectureByTeacherIdAsync(long userId)
    {
        return await _lectureService.GetLectureByTeacherIdAsync(userId);

    }

    public async Task<List<Lecture>> GetUpvotedLectureByUserIdAsync(long userId)
    {
        return await _lectureService.GetUpvotedLectureByUserIdAsync(userId);

    }

    public async Task<List<Lecture>> GetLecturesByUniversityAsync(University university)
    {
        University validUniversity = await _universityService.GetUniversityByIdAsync(university.Id);
        if (validUniversity is null)
        {
            throw new Exception("University does not exist");
        }
        return await _universityService.GetAllLecturesByUniversityAsync(validUniversity);
    }

    public async Task<List<Lecture>> GetAllLecturesAsync(int pageNumber, int pageSize)
    {
        var lectures = await _lectureService.GetAllLecturesAsync(pageNumber,pageSize);
        if (lectures is null) throw new Exception($"Lectures not found for {pageNumber} , {pageSize}");
        return lectures;
    }

    private void ValidateCreation(Lecture lecture)
    {
        if (string.IsNullOrEmpty(lecture.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(lecture.Body)) throw new Exception("Lecture body cannot be empty.");
        if (string.IsNullOrEmpty(lecture.Url)) throw new Exception("Url cannot be empty.");
    }
}