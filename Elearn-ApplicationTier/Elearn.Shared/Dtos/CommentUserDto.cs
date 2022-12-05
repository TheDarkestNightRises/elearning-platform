namespace Elearn.Shared.Dtos;

public class CommentUserDto
{
    public UserForCommentDto user{ get; set; }
    
    public long LectureId{ get; set; }
    
    public string Text { get; set; }
    
    public DateTime DateCreated { get; set; }

    public CommentUserDto(UserForCommentDto user, long lectureId, string text, DateTime dateCreated)
    {
        this.user = user;
        LectureId = lectureId;
        Text = text;
        DateCreated = dateCreated;
    }

    public CommentUserDto()
    {
    }
}