using Elearn.Shared.Models;
using ElearnGrpc;

namespace Elearn.GrpcService.Extensions;

public static class GrpcAnswerExtension
{
    public static AnswerModel AsGrpcModel(this Answer answer)
    {
        return new AnswerModel
        {
            Id = answer.AnswerId,
            Author = GrpcUserExtension.AsGrpcModel(answer.Author),
            Question = GrpcQuestionExtension.AsGrpcModel(answer.Question),
            Text = answer.Body,
            Date = GrpcDateExtension.AsGrpcModel(answer.DateCreated)
        };
    }
    
    public static Answer AsBase(this AnswerModel answerModel)
    {
        return new Answer
        {
            AnswerId = answerModel.Id,
            Author = GrpcUserExtension.AsBase(answerModel.Author),
            Question = GrpcQuestionExtension.AsBase(answerModel.Question),
            Body = answerModel.Text,
            DateCreated = GrpcDateExtension.AsBase(answerModel.Date)
        };
    }
}