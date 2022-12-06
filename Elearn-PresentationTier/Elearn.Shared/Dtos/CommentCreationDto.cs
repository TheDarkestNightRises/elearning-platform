namespace Elearn.Shared.Dtos;

public class CommentCreationDto
{
    public String Text { get; set; }
    
    public long LectureId{ get; set; }
    
    public long UserId{ get; set; }

    public CommentCreationDto(long UserId, long LectureId, string Text)
    {
        this.UserId = UserId;
        this.LectureId = LectureId;
        this.Text = Text;
    }

    public CommentCreationDto()
    {
    }

    public override string ToString()
    {
        return  $"{Text}";
    }
}