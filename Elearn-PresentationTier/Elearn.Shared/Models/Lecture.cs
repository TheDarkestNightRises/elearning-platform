using System.ComponentModel.DataAnnotations;

namespace Elearn.Shared.Models;
public class Lecture
{
    public int Id { get; set; }

    [Required, StringLength(20, ErrorMessage = "Please use only 20 characters")]
    public string Url { get; set; }
    public string Image { get; set; }
    
    [Required] public string Title { get; set; }
    
    public string Body { get; set; }
    
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public User Author { get; set; }

    public Lecture(string title, string body, string url, string image, User author)
    {
        Url = url;
        Image = image;
        Title = title;
        Body = body;
        Author = author;
    }

    public Lecture(int id, string title, string body, string url, string image, User author)
    {
        Id = id;
        Url = url;
        Image = image;
        Title = title;
        Body = body;
        Author = author;
    }

    public Lecture()
    {
        
    }
}