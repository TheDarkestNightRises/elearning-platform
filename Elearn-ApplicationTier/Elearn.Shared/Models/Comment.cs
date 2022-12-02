using System.ComponentModel.DataAnnotations;

namespace Elearn.Shared.Models;

public class Comment
{
    public long CommentId { get; set; }
    
 
    public User Author{ get; set; }
    
    public Lecture Lecture{ get; set; }
    
    
    [Required, StringLength(150, ErrorMessage = "150 Characters MAX")]
    public string Text { get; set; }
    
    public DateTime DateCreated { get; set; } = DateTime.Now;

    public Comment(User author, Lecture lecture, string text)
    {
        Author = author;
        Lecture = lecture;
        Text = text;
    }

    public Comment()
    {
    }
    
    public override string ToString()
    {
        return $"{CommentId} {Author} {Lecture} {Text} {DateCreated}";
    }
    
 

}