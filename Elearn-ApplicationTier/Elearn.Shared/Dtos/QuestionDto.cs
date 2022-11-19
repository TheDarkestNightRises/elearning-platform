using System.Globalization;
using Elearn.Shared.Models;

namespace Elearn.Shared.Dtos;

public class QuestionDto
{
    public long Id { get; set; }
    
    public string Title { get; set; }
    
    public string Body { get; set; }
    
    public string Url { get; set; }
    
    public long CreationDate { get; set; }
    
    public long CorrectAnswerId { get; set; } 
    
    public string name { get; set; }

    public QuestionDto(long id, string title, string body, string url, long creationDate, long correctAnswerId, string name)
    {
        Id = id;
        Title = title;
        Body = body;
        Url = url;
        CreationDate = creationDate;
        CorrectAnswerId = correctAnswerId;
        this.name = name;
    }


    public override string ToString()
    {
        return $"{Id} {Title} {Body} {Url}";
    }
}