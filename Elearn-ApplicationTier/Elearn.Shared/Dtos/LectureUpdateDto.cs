namespace Elearn.Shared.Dtos;

public class LectureUpdateDto
{
    public string Title{ get; set; }
    public string Body{ get; set; }
    public string Url{ get; set; } 
    public string Description { get; set; }
    public string Image { get; set; }
    public string Username{ get; set; }
    public DateTime DateCreated { get; set; }

    public LectureUpdateDto(string title, string body, string url, string description, string image, string username, DateTime dateCreated)
    {
        Title = title;
        Body = body;
        Url = url;
        Description = description;
        Image = image;
        Username = username;
        DateCreated = dateCreated;
    }

    public LectureUpdateDto()
    {
    }
   

    public override string ToString()
    {
        return $"{Title} {Body} {Url}";
    }
}