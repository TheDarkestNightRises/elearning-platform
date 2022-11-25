
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Shared.Extensions;

public static class PostExtensions
{
    public static LectureDto AsDto(this Lecture lecture) 
    {
        return new LectureDto
        {
            Id = lecture.Id,
            Url = lecture.Url,
            Image = lecture.Image,
            Title = lecture.Title,
            Body = lecture.Body,
            DateCreated = lecture.DateCreated,
            Username = lecture.Author != null ? lecture.Author.Username : String.Empty
        };
    }

    public static IEnumerable<LectureDto> AsDtos(this IEnumerable<Lecture> lectures)
    {
        var lecturesDtos = (from lecture in lectures 
            select new LectureDto 
            {
                Id = lecture.Id,
                Url = lecture.Url,
                Image = lecture.Image,
                Title = lecture.Title,
                Body = lecture.Body,
                DateCreated = lecture.DateCreated,
                Username = lecture.Author != null ? lecture.Author.Username : String.Empty
            });
        return lecturesDtos;                
    }
    
    public static Lecture AsBase(this LectureDto lectureDto) 
    {
        Lecture lecture = new Lecture
        {
            Id = lectureDto.Id,
            Url = lectureDto.Url,
            Image = lectureDto.Image,
            Title = lectureDto.Title,
            Body = lectureDto.Body,
            DateCreated = lectureDto.DateCreated,
            
        };
        lecture.Author = new Teacher();
        lecture.Author.Username = lectureDto.Username;
        return lecture;
    }
    
    public static Lecture AsBaseFromCreation(this LectureCreationDto lectureDto) 
    {
        Lecture lecture = new Lecture
        {
            Url = lectureDto.Url,
            Image = lectureDto.Image,
            Title = lectureDto.Title,
            Body = lectureDto.Body
            
        };
        lecture.Author = new Teacher();
        lecture.Author.Username = lectureDto.Username;
        return lecture;
    }
}