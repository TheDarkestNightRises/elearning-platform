using Elearn.Shared.Models;
using ElearnGrpc;

namespace Elearn.GrpcService.Extensions;

public static class GrpcQuestionExtension
{
    public static QuestionModel AsGrpcModel(this Question question)
    {
        return new QuestionModel()
        {
            Id = question.Id,
            Url = question.Url,
            Title = question.Title,
            Body = question.Body
            // in the future add correct answer
            
        };
    }

    public static Question AsBase(this QuestionModel questionModel)
    {
        return new Question()
        {
            Id = questionModel.Id,
            Url = questionModel.Url,
            Title = questionModel.Title,
            Body = questionModel.Body
        };
    }
}