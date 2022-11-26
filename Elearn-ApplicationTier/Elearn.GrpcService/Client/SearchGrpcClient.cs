using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Extensions;
using Elearn.Shared.Models;
using ElearnGrpc;
using Grpc.Core;

namespace Elearn.GrpcService.Client;

public class SearchGrpcClient : ISearchService
{
    private SearchService.SearchServiceClient _searchClient;

    public SearchGrpcClient()
    {
        var _grpcChannel =
            new Channel("localhost:8843", ChannelCredentials.Insecure);
        _searchClient = new SearchService.SearchServiceClient(_grpcChannel);
    }

    public async Task<List<User>> SearchUsersAsync(string username)
    {
        List<User> users = new List<User>();
        var request = new SearchUsersRequest() { UserName = username };
        using (var call = _searchClient.SearchUsers(request))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentUser = call.ResponseStream.Current;
                users.Add(currentUser.AsBase());
            }
        }

        return users;
    }

    public async Task<List<Lecture>> SearchLecturesAsync(string title)
    {
        List<Lecture> lectures = new List<Lecture>();
        var request = new SearchLecturesRequest { Title = title };
        using (var call = _searchClient.SearchLectures(request))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentLecture = call.ResponseStream.Current;
                lectures.Add(currentLecture.AsBase());
            }
        }

        return lectures;
    }

    public async Task<List<Question>> SearchQuestionsAsync(string title)
    {
        List<Question> questions = new List<Question>();
        var request = new SearchQuestionsRequest { Title = title };
        using (var call = _searchClient.SearchQuestions(request))
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