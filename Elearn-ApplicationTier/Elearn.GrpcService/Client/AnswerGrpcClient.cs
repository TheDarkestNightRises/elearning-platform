using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Extensions;
using Elearn.Shared.Models;
using ElearnGrpc;
using Grpc.Core;

namespace Elearn.GrpcService.Client;

public class AnswerGrpcClient : IAnswerService
{

    private AnswerService.AnswerServiceClient _answerClient;

    public AnswerGrpcClient()
    {
        var _grpcChannel =
            new Channel("localhost:8843", ChannelCredentials.Insecure);
        _answerClient = new AnswerService.AnswerServiceClient(_grpcChannel);
    }

    public async Task<Answer> CreateAsync(Answer answerAppended)
    {
        var answerModel = answerAppended.AsGrpcModel();
        var createdAnswerFromGrpc = await _answerClient.CreateNewAnswerAsync(answerModel);
        Answer answerComment = createdAnswerFromGrpc.AsBase();
        return answerComment;
    }

    public async Task<Answer?> GetAnswerById(long id)
    {
        var answerRequested = new AnswerId {  Id = id};
        var commentFromGrpc = await _answerClient.GetAnswerByIdAsync(answerRequested);
        return commentFromGrpc.AsBase();
    }

    public async Task DeleteAnswerAsync(Answer answer)
    {
        var answerModel = answer.AsGrpcModel();
        await _answerClient.DeleteAnswerAsync(answerModel);
    }

    public async Task<List<Answer>> GetAllAnswersByQuestionId(long id)
    {
        List<Answer> answers = new List<Answer>();
        var request = new QuestionId() { Id = id };
        using (var call = _answerClient.GetAnswerByQuestionId(new QuestionId(request)))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentAnswer = call.ResponseStream.Current;
                answers.Add(currentAnswer.AsBase());
            }
        }

        return answers;
    }
}