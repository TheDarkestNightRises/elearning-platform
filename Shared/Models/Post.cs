using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Post
{
    
    public int Id { get; set; }
    [Required, StringLength(20,ErrorMessage = "Please use only 20 characters")]
    public string Url { get; set; }

    public string Image { get; set; }
    [Required]
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string Author { get; set; }
}