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
        ValidateCreation(lecture);

        Teacher? teacher = await _teacherService.GetTeacherByUsernameAsync(lecture.Author.Username);
        Lecture? existingLecture = await _lectureService.GetPostAsync(lecture.Url);
        
        if (teacher is null)
        {
            throw new Exception("Teacher not found in database");
        }

        if (existingLecture is not null)
        {
            throw new Exception("This URL is already used");
        }
        
        Lecture lectureAppended = new Lecture(lecture.Url, lecture.Image, lecture.Title, lecture.Body,lecture.Description, teacher);
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

    public async Task<Lecture> EditLectureAsync(Lecture lecture)
    {
        ValidateCreation(lecture);

        Teacher? teacher = await _teacherService.GetTeacherByUsernameAsync(lecture.Author.Username);
        Lecture? existingLecture = await _lectureService.GetPostAsync(lecture.Url);

        if (teacher is null)
        {
            throw new Exception("Teacher not found in database");
        }
        if (existingLecture is null)
        {
            throw new Exception("Lecture not found");
        }
        if (!existingLecture.Author.Username.Equals(teacher.Username))
        {
            throw new Exception("Teacher cannot be changed");
        }
        
        Lecture lectureAppended = new Lecture(existingLecture.Id,existingLecture.Url, lecture.Image, lecture.Title, lecture.Body,lecture.Description, teacher);
        Lecture created = await _lectureService.EditLectureAsync(lectureAppended);
        return created;
    }

    public async Task DeleteLecture(Lecture lecture)
    {
        Lecture? lectureToDelete = await _lectureService.GetPostAsync(lecture.Url);
        if (lectureToDelete is null)
        {
            throw new Exception("Lecture not found");
        }
        await _lectureService.DeleteLecture(lectureToDelete);
    }

    private void ValidateCreation(Lecture lecture)
    {
        if (string.IsNullOrEmpty(lecture.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(lecture.Body)) throw new Exception("Lecture body cannot be empty.");
        if (string.IsNullOrEmpty(lecture.Url)) throw new Exception("Url cannot be empty.");
        if (string.IsNullOrEmpty(lecture.Description)) throw new Exception("Description cannot be empty.");
        if (string.IsNullOrEmpty(lecture.Image)) throw new Exception("Image cannot be empty.");
        if (string.IsNullOrEmpty(lecture.DateCreated.ToString())) throw new Exception("Date cannot be empty.");
    }
}