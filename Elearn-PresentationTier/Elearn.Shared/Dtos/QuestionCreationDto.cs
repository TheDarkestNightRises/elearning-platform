namespace Elearn.Shared.Dtos;

public class QuestionCreationDto
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string Url { get; set; }
    
    public string Description{ get; set; }
    
    public DateTime CreationDate { get; set; } = DateTime.Now;

    public bool CorrectAnswer { get; set; } = false;

    public string AuthorName { get; set; }

    public QuestionCreationDto()
    {
    }

    public QuestionCreationDto(string title, string body, string url, string description, string authorName)
    {
        Title = title;
        Body = body;
        Url = url;
        Description = description;
        AuthorName = authorName;
    }
}