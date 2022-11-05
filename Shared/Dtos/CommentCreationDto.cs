namespace Shared.Dtos;

public class CommentCreationDto
{
    //Actual user needed
    public String Text { get; set; }
    
    public int PostId{ get; set; }
    
    public int UserId{ get; set; }

    public CommentCreationDto(int UserId, int PostId, string Text)
    {
        this.UserId = UserId;
        this.PostId = PostId;
        this.Text = Text;
    }
    
    public override string ToString()
    {
        return  $"{Text}";
    }
}