namespace Shared.Dtos;

public class SearchCommentParametersDto
{
    public string? CommentId { get;}
    
    public string? UserId { get;}
    
    public string? PostId { get;}

    public SearchCommentParametersDto(string? commentId, string? userId, string? postId)
    {
        CommentId = commentId;
        UserId = userId;
        PostId = postId;
    }
}