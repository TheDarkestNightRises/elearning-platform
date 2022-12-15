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
            Id = question.Id,
            Url = question.Url,
            Title = question.Title,
            Body = question.Body,
            Description = question.Description,
            CreationDate = question.CreationDate,
            AuthorName = question.Author.Username,
            CorrectAnswer = question.CorrectAnswer,
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
                Id = question.Id,
                Url = question.Url,
                Title = question.Title,
                Body = question.Body,
                Description = question.Description,
                CreationDate = question.CreationDate,
                AuthorName = question.Author.Username,
                CorrectAnswer = question.CorrectAnswer,
            };
        return questionsResult;
    }

    public static Question AsBase(this QuestionDto questionDto)
    {
       Question question = new Question
        {
            Id = questionDto.Id,
            Url = questionDto.Url,
            Title = questionDto.Title,
            Body = questionDto.Body,
            CreationDate = questionDto.CreationDate,
            CorrectAnswer = questionDto.CorrectAnswer,
            Description = questionDto.Description
            
            
        };
        question.Author = new Student();
        question.Author.Username = questionDto.AuthorName;
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
            CorrectAnswer = questionDto.CorrectAnswer
        };
        question.Author = new Student();
        question.Author.Username = questionDto.AuthorName;
        return question;
    }
    public static Question AsBaseFromUpdate(this QuestionUpdateDto questionDto)
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
        question.Author.Username = questionDto.AuthorName;
        return question;
    }
}