using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Models;


namespace Elearn.Application.Logic;

public class QuestionLogic : IQuestionLogic
{
    private IQuestionService _questionService;
    private IUserService _userService;

    public QuestionLogic(IQuestionService questionService, IUserService userService)
    {
        _questionService = questionService;
        _userService = userService;
    }

    public async Task<Question> CreateQuestionAsync(Question question)
    {
        var user = await _userService.GetUserByNameAsync(question.Author.Name);
        if (user is null)
        {
            throw new Exception("User not found");
        }
        question.Author = user;
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
}