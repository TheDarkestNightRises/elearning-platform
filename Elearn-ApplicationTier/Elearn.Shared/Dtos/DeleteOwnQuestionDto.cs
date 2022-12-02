namespace Elearn.Shared.Dtos;

public class DeleteOwnQuestionDto
{
    
    public string QuestionId { get; set; }
    
    public string QuestionTitle { get; set; }
    
    public string QuestioBody { get; set; }
    
    public string QuestionUrl { get; set; }
    
    public string QuestionDataCreated { get; set; }
    
    public string CorrectAnswer { get; set; }

    public DeleteOwnQuestionDto(string questionId, string questionTitle, string questioBody, string questionUrl, string questionDataCreated, string correctAnswer)
    {
        QuestionId = questionId;
        QuestionTitle = questionTitle;
        QuestioBody = questioBody;
        QuestionUrl = questionUrl;
        QuestionDataCreated = questionDataCreated;
        CorrectAnswer = correctAnswer;
    }
    
    public DeleteOwnQuestionDto()
    {
        
    }

    public override string ToString()
    {
        return $"{nameof(QuestionId)}: {QuestionId}, {nameof(QuestionTitle)}: {QuestionTitle}, {nameof(QuestioBody)}: {QuestioBody}, {nameof(QuestionUrl)}: {QuestionUrl}, {nameof(QuestionDataCreated)}: {QuestionDataCreated}, {nameof(CorrectAnswer)}: {CorrectAnswer}";
    }
}