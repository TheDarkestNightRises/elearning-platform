using Elearn.Shared.Models;

namespace Elearn.Shared.Dtos;

public class PostDto
{
    public long Id { get; set; }
    public string Title{ get; set; }
    public string Body{ get; set; }
    public string Url{ get; set; } 
    public string Image { get; set; }
    public string Username{ get; set; }
    public DateTime DateCreated { get; set; }

    public PostDto()
    {
        
    }
    public PostDto(int id, string title, string body, string url, string image, string username, DateTime dateCreated)
    {
        Id = id;
        Title = title;
        Body = body;
        Url = url;
        Image = image;
        Username = username;
        DateCreated = dateCreated;
    }

    public override string ToString()
    {
        return $"{Id} {Title} {Body} {Url}";
    }
}