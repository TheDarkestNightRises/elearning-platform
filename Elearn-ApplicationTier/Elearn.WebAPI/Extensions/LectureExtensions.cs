
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
            DateCreated = lecture.DateCreated
        };
    }

    public static IEnumerable<LectureDto> AsDto(this IEnumerable<Lecture> lectures)
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
                Username = lecture.Author.Username
            });
        return lecturesDtos;                
    }
    
    public static Lecture AsBase(this LectureDto lectureDto) 
    {
        return new Lecture
        {
            Id = lectureDto.Id,
            Url = lectureDto.Url,
            Image = lectureDto.Image,
            Title = lectureDto.Title,
            Body = lectureDto.Body,
            DateCreated = lectureDto.DateCreated,
            
        };
    }
    
    public static Lecture AsBaseFromCreation(this LectureCreationDto lectureDto) 
    {
        return new Lecture
        {
            Url = lectureDto.Url,
            Image = lectureDto.Image,
            Title = lectureDto.Title,
            Body = lectureDto.Body,
            //Author = postDto.Author
        };
    }
}