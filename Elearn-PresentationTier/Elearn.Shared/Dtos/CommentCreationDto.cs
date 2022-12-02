namespace Elearn.Shared.Dtos;

public class CommentCreationDto
{
    //Actual user needed
    public String Text { get; set; }
    
    public int LectureId{ get; set; }
    
    public int UserId{ get; set; }

    public CommentCreationDto(int UserId, int LectureId, string Text)
    {
        this.UserId = UserId;
        this.LectureId = LectureId;
        this.Text = Text;
    }
    
    public override string ToString()
    {
        return  $"{Text}";
    }
}