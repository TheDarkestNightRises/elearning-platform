using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Models;

namespace Elearn.Application.Logic;

public class AnswerLogic : IAnswerLogic
{
    private readonly IQuestionService _questionService;
    private readonly IAnswerService _answerService;
    private readonly IUserService _userService;

    public AnswerLogic(IQuestionService questionService, IAnswerService answerService, IUserService userService)
    {
        _questionService = questionService;
        _answerService = answerService;
        _userService = userService;
    }

    public async Task<Answer> CreateAsync(Answer answer)
    {
        Question? question = await _questionService.GetQuestionByIdAsync(answer.Question.Id);
        User? user = await _userService.GetUserByIdAsync(answer.Author.Id);
        if (question == null)
        {
            throw new Exception($"Question was not found.");
        }
        if (user == null)
        {
            throw new Exception($"User was not found.");
        }
        ValidateAnswer(answer);
        Answer answerAppended = new Answer(user,question,answer.Body,answer.CorrectAnswer);
        Answer created = await _answerService.CreateAsync(answerAppended);
        return created;
    }

    public async Task DeleteAnswerAsync(long id)
    {
        Answer? answer = await _answerService.GetAnswerById(id);
        if (answer == null)
        {
            throw new Exception($"Answer with id {id} was not found.");
        }
        await _answerService.DeleteAnswerAsync(answer);
    }

    public async Task<List<Answer>> GetAllAnswersByQuestionId(long id)
    {
        return await _answerService.GetAllAnswersByQuestionId(id);
    }
    
    private void ValidateAnswer(Answer answer)
    {
        if (string.IsNullOrEmpty(answer.Body)) throw new Exception("Input cannot be empty.");
    }
}