using System.ComponentModel.DataAnnotations;

namespace Elearn.Shared.Models;

public class Answer
{
    public long AnswerId { get; set; }
    
 
    public User Author{ get; set; }
    
    public Question Question{ get; set; }
    
    
    [Required, StringLength(150, ErrorMessage = "150 Characters MAX")]
    public string Body { get; set; }
    
    public DateTime DateCreated { get; set; } = DateTime.Now;

    public bool CorrectAnswer { get; set; }

    public Answer(User author, Question question, string body, bool correctAnswer)
    {
        Author = author;
        Question = question;
        Body = body;
        CorrectAnswer = correctAnswer;

    }

    public Answer()
    {
    }

    public override string ToString()
    {
        return $"{AnswerId} {Author} {Question} {Body} {DateCreated}";
    }
}