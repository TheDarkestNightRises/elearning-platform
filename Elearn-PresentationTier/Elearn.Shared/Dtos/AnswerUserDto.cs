namespace Elearn.Shared.Dtos;

public class AnswerUserDto
{
    public UserForAnswerDto User{ get; set; }
    
    public long Id { get; set; }
    public long QuestionId{ get; set; }
    
    public string Body { get; set; }
    
    public DateTime DateCreated { get; set; }
    
    public bool CorrectAnswer { get; set; }

    public AnswerUserDto()
    {
    }

    public AnswerUserDto(UserForAnswerDto user, long id, long questionId, string body, DateTime dateCreated, bool correctAnswer)
    {
        User = user;
        Id = id;
        QuestionId = questionId;
        Body = body;
        DateCreated = dateCreated;
        CorrectAnswer = correctAnswer;
    }
}