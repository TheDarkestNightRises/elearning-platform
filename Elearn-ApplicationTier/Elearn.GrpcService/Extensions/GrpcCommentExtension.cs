using Elearn.Shared.Models;
using ElearnGrpc;

namespace Elearn.GrpcService.Extensions;

public static class GrpcCommentExtension
{
    public static CommentModel AsGrpcModel(this Comment comment)
    {
        return new CommentModel
        {
            Id = comment.CommentId,
            Author = GrpcUserExtension.AsGrpcModel(comment.Author),
            Lecture = GrpcLectureExtension.AsGrpcModel(comment.Lecture),
            Text = comment.Text,
            Date = GrpcDateExtension.AsGrpcModel(comment.DateCreated)
        };
    }
    
    public static Comment AsBase(this CommentModel commentModel)
    {
        return new Comment
        {
            CommentId = commentModel.Id,
            Author = GrpcUserExtension.AsBase(commentModel.Author),
            Lecture = GrpcLectureExtension.AsBase(commentModel.Lecture),
            Text = commentModel.Text,
            DateCreated = GrpcDateExtension.AsBase(commentModel.Date)
        };
    }
}