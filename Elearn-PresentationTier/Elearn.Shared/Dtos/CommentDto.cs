using Elearn.Shared.Models;

namespace Elearn.Shared.Dtos;

public class CommentDto
{
    public int Id { get; set; }
    
    //Actual user needed
    public int AuthorId{ get; set; }
    
    public Lecture Lecture{ get; set; }
    
    public String Text { get; set; }
    
    public DateTime DateCreated { get; set; } 

    public CommentDto(int AuthorId, Lecture lecture, string Text, DateTime dateCreated)
    {
        this.AuthorId = AuthorId;
        this.Lecture = lecture;
        this.Text = Text;
        DateCreated = dateCreated;
    }
    
    public override string ToString()
    {
        return $"{Id} {AuthorId} {Lecture} {Text} {DateCreated}";
    }

}