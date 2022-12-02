using Elearn.Shared.Models;

namespace Elearn.Shared.Dtos;

public class CommentDto
{
    public int Id { get; set; }
    
    //Actual user needed
    public int AuthorId{ get; set; }
    
    public long LectureId{ get; set; }
    
    public String Text { get; set; }
    
    public DateTime DateCreated { get; set; } 

    public CommentDto(int AuthorId, long lectureId, string Text, DateTime dateCreated)
    {
        this.AuthorId = AuthorId;
        this.LectureId = lectureId;
        this.Text = Text;
        DateCreated = dateCreated;
    }
    
    public override string ToString()
    {
        return $"{Id} {AuthorId} {LectureId} {Text} {DateCreated}";
    }

}