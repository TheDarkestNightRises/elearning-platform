using System.ComponentModel.DataAnnotations;

namespace Elearn.Shared.Models;

public class Comment
{
    public int CommentId { get; set; }
    
    //Actual user needed
    public int AuthorId{ get; set; }
    
    public Lecture Lecture{ get; set; }
    
    
    [Required, StringLength(150, ErrorMessage = "150 Characters MAX")]
    public string Text { get; set; }
    
    public DateTime DateCreated { get; set; } = DateTime.Now;

    public Comment(int authorId, Lecture lecture, string text)
    {
        AuthorId = authorId;
        Lecture = lecture;
        Text = text;
    }

    public Comment()
    {
        
    }
    public override string ToString()
    {
        return $"{CommentId} {AuthorId} {Lecture} {Text} {DateCreated}";
    }
    
 

}