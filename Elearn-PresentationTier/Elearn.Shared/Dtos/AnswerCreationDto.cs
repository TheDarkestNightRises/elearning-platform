namespace Elearn.Shared.Dtos;

public class AnswerCreationDto
{
    public String Body { get; set; }
    
    public long QuestionId{ get; set; }
    
    public long UserId{ get; set; }
    
    public bool CorrectAnswer { get; set; }

    public AnswerCreationDto(string body, long questionId, long userId, bool correctAnswer)
    {
        Body = body;
        QuestionId = questionId;
        UserId = userId;
        CorrectAnswer = correctAnswer;
    }

    public AnswerCreationDto()
    {
    }
    
    public override string ToString()
    {
        return  $"{Body}";
    }

}