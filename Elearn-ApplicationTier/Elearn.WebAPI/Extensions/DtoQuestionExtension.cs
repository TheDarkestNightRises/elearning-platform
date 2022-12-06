using System.Diagnostics;
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
            Description = question.Description,
            CreationDate = question.CreationDate,
            AuthorName = question.Author.Username,
            CorrectAnswerId = question.CorrectAnswerId,
        };
    }

    public static IEnumerable<QuestionDto> AsDtos(this IEnumerable<Question> questions)
    {
        foreach(Question question in questions)
        {
            Console.WriteLine(question);
        }
        
        var questionsResult = from question in questions
            select new QuestionDto
            {
                Url = question.Url,
                Title = question.Title,
                Body = question.Body,
                Description = question.Description,
                CreationDate = question.CreationDate,
                AuthorName = question.Author.Username,
                CorrectAnswerId = question.CorrectAnswerId,
            };
        return questionsResult;
    }

    public static Question AsBase(this QuestionDto questionDto)
    {
       Question question = new Question
        {
            Url = questionDto.Url,
            Title = questionDto.Title,
            Body = questionDto.Body,
            CreationDate = questionDto.CreationDate,
            CorrectAnswerId = questionDto.CorrectAnswerId
            
        };
        question.Author = new Student();
        question.Author.Name = questionDto.AuthorName;
        return question;
    }

    public static Question AsBaseFromCreation(this QuestionCreationDto questionDto)
    {
        var question = new Question
        {
            Url = questionDto.Url,
            Title = questionDto.Title,
            Body = questionDto.Body,
            Description = questionDto.Description,
            CreationDate = questionDto.CreationDate,
        };
        question.Author = new Student();
        question.Author.Name = questionDto.AuthorName;
        return question;
    }
}