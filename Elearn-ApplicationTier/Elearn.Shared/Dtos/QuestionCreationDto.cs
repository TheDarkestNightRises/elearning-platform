namespace Elearn.Shared.Dtos;

public class QuestionCreationDto
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string Url { get; set; }
    
    public string Description{ get; set; }

    public DateTime CreationDate { get; set; } = DateTime.Now;

    public string AuthorName { get; set; }
    
    public bool CorrectAnswer { get; set; } 
}