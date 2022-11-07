
using Elearn.Shared.Models;

namespace Elearn.Shared.Dtos;

public class PostCreationDto
{
    public string Title{ get; set; }
    public string Body{ get; set; }
    public string Url{ get; set; }
    public string Image { get; set; }
    public int AuthorId{ get; set; }

    public PostCreationDto(string title, string body, string url, string image, int authorId)
    {
        Title = title;
        Body = body;
        Url = url;
        Image = image;
        AuthorId = authorId;
    }

    public override string ToString()
    {
        return $"{Title} {Body} {Url}";
    }
}