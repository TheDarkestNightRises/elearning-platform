
using Elearn.Shared.Models;

namespace Elearn.Shared.Dtos;

public class PostCreationDto
{
    public string Title{ get; set; }
    public string Body{ get; set; }
    public string Url{ get; set; }
    public string Image { get; set; }
    public User Author{ get; set; }

    public PostCreationDto(string title, string body, string url, string image, User author)
    {
        Title = title;
        Body = body;
        Url = url;
        Image = image;
        Author = author;
    }

    public override string ToString()
    {
        return $"{Title} {Body} {Url}";
    }
}