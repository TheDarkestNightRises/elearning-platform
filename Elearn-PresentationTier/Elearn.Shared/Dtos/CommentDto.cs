using Elearn.Shared.Models;

namespace Elearn.Shared.Dtos;

public class CommentDto
{
    public long Id { get; set; }
    
    
    public long AuthorId{ get; set; }
    
    public long LectureId{ get; set; }
    
    public String Text { get; set; }
    
    public DateTime DateCreated { get; set; } 

    public CommentDto(long AuthorId, long LectureId, string Text, DateTime dateCreated)
    {
        this.AuthorId = AuthorId;
        this.LectureId = LectureId;
        this.Text = Text;
        DateCreated = dateCreated;
    }
    
    public CommentDto(long Id,int AuthorId, long LectureId, string Text, DateTime dateCreated)
    {
        this.Id = Id;
        this.AuthorId = AuthorId;
        this.LectureId = LectureId;
        this.Text = Text;
        DateCreated = dateCreated;
    }

    public CommentDto()
    {
    }


    public override string ToString()
    {
        return $"{Id} {AuthorId} {LectureId} {Text} {DateCreated}";
    }

}