using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Shared.Extensions;

public static class QuestionExtension
{
    public static QuestionDto AsDto(this Question question)
    {
        return new QuestionDto
        {
            Url = question.Url,
            Title = question.Title,
            Body = question.Body,
            CorrectAnswerId = question.CorrectAnswerId,
            AuthorName = question.Author.Name,
        };
    }

    public static IEnumerable<QuestionDto> AsDtos(this IEnumerable<Question> questions)
    {
        var questionsResult = from question in questions
            select new QuestionDto
            {
                Url = question.Url,
                Title = question.Title,
                Body = question.Body,
                CorrectAnswerId = question.CorrectAnswerId,
                AuthorName = question.Author.Name,
            };
        return questionsResult;
    }

    public static Question AsBase(this QuestionDto questionDto)
    {
        return new Question
        {
            Url = questionDto.Url,
            Title = questionDto.Title,
            Body = questionDto.Body,
            CreationDate = questionDto.CreationDate,
            CorrectAnswerId = questionDto.CorrectAnswerId
        };
    }

    public static Question AsBaseFromCreation(this QuestionCreationDto questionDto)
    {
        var question = new Question
        {
            Url = questionDto.Url,
            Title = questionDto.Title,
            Body = questionDto.Body,
            CreationDate = questionDto.CreationDate,
        };
        question.Author = new User();
        question.Author.Name = questionDto.AuthorName;
        return question;
    }
}