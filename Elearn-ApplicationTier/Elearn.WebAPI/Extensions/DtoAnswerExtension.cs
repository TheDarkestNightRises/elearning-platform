using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Shared.Extensions;

public static class DtoAnswerExtension
{
    public static Answer AsBaseFromCreation(this AnswerCreationDto answerDto) 
    {
        Answer answer = new Answer
        {
            Body = answerDto.Body,
            CorrectAnswer = answerDto.CorrectAnswer,
        };
        answer.Author = new User();
        answer.Author.Id = answerDto.UserId;
        answer.Question = new Question();
        answer.Question.Id = answerDto.QuestionId;
        return answer;
    }
    
    public static IEnumerable<AnswerUserDto> AsDtos(this IEnumerable<Answer> answers)
    {
        var answerDtos = (from answer in answers
            select new AnswerUserDto
            {
                Id = answer.AnswerId,
                User  = answer.Author.AsUserForAnswerDto(),
                QuestionId  = answer.Question.Id,
                DateCreated  = answer.DateCreated,
                Body = answer.Body,
                CorrectAnswer = answer.CorrectAnswer
            });
        return answerDtos;                
    }
    
    public static AnswerDto AsDto(this Answer answer) 
    {
        return new AnswerDto
        {
            Id = answer.AnswerId,
            AuthorId = answer.Author.Id,
            QuestionId = answer.Question.Id,
            Body =  answer.Body,
            DateCreated = answer.DateCreated,
            CorrectAnswer = answer.CorrectAnswer
        };
    }
}