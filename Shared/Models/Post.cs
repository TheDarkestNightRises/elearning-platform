using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shared.Models;
[Index( nameof(Url), IsUnique=true)] 
public class Post
{
    
    public int PostId { get; set; }
    [Required, StringLength(20,ErrorMessage = "Please use only 20 characters")]
    public string Url { get; set; }
    public string Image { get; set; }
    [Required]
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public User Author { get; set; }

    public Post(string url, string image, string title, string body, User author)
    {
        Url = url;
        Image = image;
        Title = title;
        Body = body;
        Author = author;
    }

    public Post(int postId, string url, string image, string title, string body, User author)
    {
        PostId = postId;
        Url = url;
        Image = image;
        Title = title;
        Body = body;
        Author = author;
    }

    public Post()
    {
        
    }
}