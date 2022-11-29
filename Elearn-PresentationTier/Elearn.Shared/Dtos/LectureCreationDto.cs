
using Elearn.Shared.Models;

namespace Elearn.Shared.Dtos;

public class LectureCreationDto
{
    public string Title{ get; set; }
    public string Body{ get; set; }
    public string Url{ get; set; }
    public string Image { get; set; }
    public string Username{ get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public LectureCreationDto(string title, string body, string url, string image, string username)
    {
        Title = title;
        Body = body;
        Url = url;
        Image = image;
        Username = username;
    }

    public LectureCreationDto()
    {
    }


    public override string ToString()
    {
        return $"{Title} {Body} {Url}";
    }
}