using System.ComponentModel.DataAnnotations;

namespace Elearn.Shared.Models;
public class Lecture
{
    public long Id { get; set; }

    [Required, StringLength(20, ErrorMessage = "Please use only 20 characters")]
    public string Url { get; set; }
    public string Image { get; set; }
    
    [Required] public string Title { get; set; }
    
    public string Body { get; set; }
    
    public string Description { get; set; }
    
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public Teacher Author { get; set; }

    public Lecture(string url, string image, string title, string body, string description, Teacher author)
    {
        Url = url;
        Image = image;
        Title = title;
        Body = body;
        Description = description;
        Author = author;
    }

    public Lecture(long id, string url, string image, string title, string body, string description, Teacher author)
    {
        Id = id;
        Url = url;
        Image = image;
        Title = title;
        Body = body;
        Description = description;
        Author = author;
    }


    public Lecture()
    {
        
    }
}