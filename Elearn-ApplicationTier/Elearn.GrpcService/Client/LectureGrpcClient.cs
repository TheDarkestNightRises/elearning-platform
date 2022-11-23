using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Extensions;
using Elearn.Shared.Models;
using ElearnGrpc;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;

namespace Elearn.GrpcService.Client;

public class LectureGrpcClient : ILectureService
{
    private LectureService.LectureServiceClient _lectureClient;

    public LectureGrpcClient()
    {
        var _grpcChannel =
            new Channel("localhost:8843", ChannelCredentials.Insecure);
        _lectureClient = new LectureService.LectureServiceClient(_grpcChannel);
    }

    public async Task<List<Lecture>> GetAllPostsAsync()
    {
        List<Lecture> lectures = new List<Lecture>();
        using (var call = _lectureClient.GetAllLectures(new NewLectureRequest()))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentLecture = call.ResponseStream.Current;
                lectures.Add(currentLecture.AsBase());
            }
        }
        return lectures;
    }

    public async Task<Lecture?> GetPostAsync(string url)
    {
        var lectureRequested = new LectureUrl { Url = url };
        var postFromGrpc = await _lectureClient.GetLectureAsync(lectureRequested);
        return postFromGrpc.AsBase();
    }

    public async Task<Lecture> CreateNewPostAsync(Lecture lecture)
    {
        var postModel = lecture.AsGrpcModel();
        //Append user to post
        var userModel = lecture.Author.AsGrpcModel();
        postModel.User = userModel;
        var createdPostFromGrpc = await _lectureClient.CreateNewLectureAsync(postModel);
        return createdPostFromGrpc.AsBase();
    }
    
    public async Task<Lecture?> GetByIdAsync(int id)
    {
        var lectureRequested = new LectureId { Id = id };
        var lectureGrpcModel = await _lectureClient.GetLectureByIdAsync(lectureRequested);
        return lectureGrpcModel.AsBase();    
    }
}