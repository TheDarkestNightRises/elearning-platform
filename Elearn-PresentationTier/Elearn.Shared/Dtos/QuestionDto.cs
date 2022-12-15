namespace Elearn.Shared.Dtos;

public class QuestionDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    
    public string Body { get; set; }
    
    public string Url { get; set; }
    
    public DateTime CreationDate { get; set; }
    
    public long CorrectAnswerId { get; set; } 
    
    public string AuthorName { get; set; }
    public string Description { get; set; }

    public QuestionDto()
    {
    }
}