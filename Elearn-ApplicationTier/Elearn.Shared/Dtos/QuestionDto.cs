using System.Globalization;
using Elearn.Shared.Models;

namespace Elearn.Shared.Dtos;

public class QuestionDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    
    public string Body { get; set; }
    
    public string Description { get; set; }
    
    public string Url { get; set; }
    
    public DateTime CreationDate { get; set; }
    
    public bool CorrectAnswer { get; set; } 
    
    public string AuthorName { get; set; }

    public QuestionDto(string title, string body, string description, string url, DateTime creationDate, bool correctAnswer, string authorName)
    {
        Title = title;
        Body = body;
        Description = description;
        Url = url;
        CreationDate = creationDate;
        CorrectAnswer = correctAnswer;
        AuthorName = authorName;
    }

    public QuestionDto()
    {
    }
}