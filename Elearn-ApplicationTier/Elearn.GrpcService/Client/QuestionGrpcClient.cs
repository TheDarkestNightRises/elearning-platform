using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Extensions;
using Elearn.Shared.Models;
using ElearnGrpc;
using Grpc.Core;


namespace Elearn.GrpcService.Client;

public class QuestionGrpcClient : IQuestionService
{
    private QuestionService.QuestionServiceClient _questionClient;

    public QuestionGrpcClient()
    {
        var _grpcChannel =
            new Channel("localhost:8843", ChannelCredentials.Insecure);
        _questionClient = new QuestionService.QuestionServiceClient(_grpcChannel);
    }

    public async Task<List<Question>> GetAllQuestionsAsync()
    {
        List<Question> questions = new List<Question>();
        using (var call = _questionClient.GetAllQuestion(new Pagination()))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentQuestion = call.ResponseStream.Current;
                questions.Add(currentQuestion.AsBase());
            }
        }

        return questions;
    }

    public async Task<Question?> GetQuestionByUrlAsync(string url)
    {
        var questionRequested = new QuestionUrl { Url = url };
        var questionFromDB = await _questionClient.GetQuestionAsync(questionRequested);
        return questionFromDB.AsBase();
    }

    public Task<Question> CreateNewQuestionAsync(Question question)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Question>> GetQuestionByUserIdAsync(int userId)
    {
        List<Question> questions = new List<Question>();
        var request = new QuestionUserId() { UserId = userId };
        using (var call = _questionClient.GetQuestionsByUserId(new QuestionUserId(request)))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentQuestion = call.ResponseStream.Current;
                questions.Add(currentQuestion.AsBase());
            }
        }

        return questions;
    }
}