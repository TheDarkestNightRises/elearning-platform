using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Application.Logic;

public class DeleteOwnQuestionLogic
{
    private readonly IQuestionLogic _questionLogic;
    private readonly IQuestionService _questionService;
    
    public DeleteOwnQuestionLogic(IQuestionLogic questionLogic, IQuestionService questionService)
    {
        _questionLogic = questionLogic;
        _questionService = questionService;
    }

    public async Task<DeleteOwnQuestion>CreaateAsync(Question question)
    {
        return new DeleteOwnQuestion();
    }
}