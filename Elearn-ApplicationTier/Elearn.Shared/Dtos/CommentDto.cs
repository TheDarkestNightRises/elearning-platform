

namespace Elearn.Shared.Dtos;

public class CommentDto
{
    public long Id { get; set; }
    
    public long AuthorId{ get; set; }
    
    public long LectureId{ get; set; }
    
    public string Text { get; set; }
    
    public DateTime DateCreated { get; set; } 

    public CommentDto(long AuthorId, long LectureId, string Text, DateTime dateCreated)
    {
        this.AuthorId = AuthorId;
        this.LectureId = LectureId;
        this.Text = Text;
        DateCreated = dateCreated;
    }

    public CommentDto(long id, long authorId, long lectureId, string text, DateTime dateCreated)
    {
        Id = id;
        AuthorId = authorId;
        LectureId = lectureId;
        Text = text;
        DateCreated = dateCreated;
    }

    public override string ToString()
    {
        return $"{Id} {AuthorId} {LectureId} {Text} {DateCreated}";
    }

    public CommentDto()
    {
    }
}