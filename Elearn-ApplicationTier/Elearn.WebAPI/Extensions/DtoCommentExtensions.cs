using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Shared.Extensions;

public static class DtoCommentExtensions
{
    public static Comment AsBaseFromCreation(this CommentCreationDto commentDto) 
    {
        Comment comment = new Comment
        {
            Text = commentDto.Text
        };
        comment.Author = new User();
        comment.Author.Id = commentDto.UserId;
        comment.Lecture = new Lecture();
        comment.Lecture.Id = commentDto.LectureId;
        return comment;
    }
    
    public static IEnumerable<CommentUserDto> AsDtos(this IEnumerable<Comment> comments)
    {
        var commentDtos = (from comment in comments 
            select new CommentUserDto
            {
                Id = comment.CommentId,
                user  = comment.Author.AsUserForCommentDto(),
              LectureId  = comment.Lecture.Id,
              DateCreated  = comment.DateCreated,
              Text = comment.Text
            });
        return commentDtos;                
    }
    
    public static CommentDto AsDto(this Comment comment) 
    {
        return new CommentDto
        {
            Id = comment.CommentId,
            AuthorId = comment.Author.Id,
            LectureId = comment.Lecture.Id,
            Text =  comment.Text,
            DateCreated = comment.DateCreated
        };
    }
}