using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Models;


namespace Elearn.Application.Logic;

public class QuestionLogic : IQuestionLogic
{
    private IQuestionService _questionService;
    private IStudentService _userService;

    public QuestionLogic(IQuestionService questionService, IStudentService userService)
    {
        _questionService = questionService;
        _userService = userService;
    }

    public async Task<Question> CreateQuestionAsync(Question question)
    {
        var student = await _userService.GetStudentByUsernameAsync(question.Author.Username);
        if (student is null)
        {
            throw new Exception("Student not found");
        }
        question.Author = student;
        var createdQuestion = await _questionService.CreateNewQuestionAsync(question);
        return createdQuestion;
    }

    public async Task<Question> GetQuestionByUrlAsync(string url)
    {
        
        var question = await _questionService.GetQuestionByUrlAsync(url);
        if (question is null) throw new Exception("Question Not Found At " + url);
        return question;
    }

    public async Task<List<Question>> GetQuestionsAsync()
    {
        var questions = await _questionService.GetAllQuestionsAsync();
        if (questions is null) throw new Exception("Questions Not Found");
        return questions;
    }

    public async Task<List<Question>> GetQuestionByUserIdAsync(long userId)
    {
        return await _questionService.GetQuestionByUserIdAsync(userId);
    }

    public async Task<List<Question>> GetQuestionsAsync(int pageNumber, int pageSize)
    {
        var questions = await _questionService.GetAllQuestionsAsync(pageNumber,pageSize);
        if (questions is null) throw new Exception($"Lectures not found for {pageNumber} , {pageSize}");
        return questions;
    }


    public async Task DeleteQuestionAsync(string url)
    {
        Question? questionToDelete = await _questionService.GetQuestionByUrlAsync(url);
        if (questionToDelete is null)
        {
            throw new Exception("Lecture not found");
        }
        await _questionService.DeleteQuestionAsync(questionToDelete);


    public async Task<Question> EditQuestionAsync(Question question)
    {
        Student? student = null;
        Question? existingQuestion = null;
        try
        {
            student = await _userService.GetStudentByUsernameAsync(question.Author.Username);
        }
        catch (Exception ex)
        {
            throw new Exception("Student not found");
        }
        try
        {
             existingQuestion = await _questionService.GetQuestionByUrlAsync(question.Url);
        }
        catch (Exception ex)
        {
            throw new Exception("Question not found");
        }
        
        

        if (student is null)
        {
            throw new Exception("Teacher not found in database");
        }
        if (existingQuestion is null)
        {
            throw new Exception("Lecture not found");
        }
        if (!existingQuestion.Author.Username.Equals(student.Username))
        {
            throw new Exception("Teacher cannot be changed");
        }

        Question questionEdit = new Question()
        {
            Id = existingQuestion.Id,
            Title = question.Title,
            Body = question.Body,
            Description = question.Description,
            Url = existingQuestion.Url,
            CreationDate = existingQuestion.CreationDate,
            Author = student
        };
        Question edited = await _questionService.EditQuestionAsync(questionEdit);
        return edited;

    }
}