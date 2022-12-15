namespace Elearn.Shared.Dtos;

public class AnswerDto
{
    public long Id { get; set; }
    
    public long AuthorId{ get; set; }
    
    public long QuestionId{ get; set; }
    
    public string Body { get; set; }
    
    public DateTime DateCreated { get; set; } 
    
    public bool CorrectAnswer { get; set; }

    public AnswerDto(long id, long authorId, long questionId, string body, DateTime dateCreated, bool correctAnswer)
    {
        Id = id;
        AuthorId = authorId;
        QuestionId = questionId;
        Body = body;
        DateCreated = dateCreated;
        CorrectAnswer = correctAnswer;
    }

    public AnswerDto(long authorId, long questionId, string body, DateTime dateCreated, bool correctAnswer)
    {
        AuthorId = authorId;
        QuestionId = questionId;
        Body = body;
        DateCreated = dateCreated;
        CorrectAnswer = correctAnswer;
    }

    public override string ToString()
    {
        return $"{Id} {AuthorId} {QuestionId} {Body} {DateCreated}";
    }

    public AnswerDto()
    {
    }
}