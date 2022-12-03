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

    public async Task<List<Lecture>> GetAllLecturesAsync()
    {
        List<Lecture> lectures = new List<Lecture>();
        using (var call = _lectureClient.GetAllLectures(new PaginationModel()))
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
        //var teacherModel = lecture.Author.AsGrpcModel();
        //postModel.Teacher = teacherModel;
        var createdPostFromGrpc = await _lectureClient.CreateNewLectureAsync(postModel);
        Lecture createdLecture = createdPostFromGrpc.AsBase();
        //createdLecture.Author = createdPostFromGrpc.Teacher.AsBase();
        return createdLecture;
    }

    public async Task<Lecture?> GetByIdAsync(int id)
    {
        var lectureRequested = new LectureId { Id = id };
        var lectureGrpcModel = await _lectureClient.GetLectureByIdAsync(lectureRequested);
        return lectureGrpcModel.AsBase();
    }

    public async Task<List<Lecture>> GetLectureByUserIdAsync(long userId)
    {
        List<Lecture> lectures = new List<Lecture>();
        var request = new LectureUserId() { UserId = userId };
        using (var call = _lectureClient.GetLectureByUserId(new LectureUserId(request)))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentLecture = call.ResponseStream.Current;
                lectures.Add(currentLecture.AsBase());
            }
        }

        return lectures;    }


    public async Task<List<Lecture>> GetUpvotedLectureByUserIdAsync(long userId)
    {
        List<Lecture> lectures = new List<Lecture>();
        var request = new LectureUserId() { UserId = userId };
        using (var call = _lectureClient.GetUpvotedLectureByUserId(new LectureUserId(request)))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentLecture = call.ResponseStream.Current;
                lectures.Add(currentLecture.AsBase());
            }
        }

        return lectures;     }

    public async Task<List<Lecture>> GetAllLecturesAsync(int pageNumber, int pageSize)
    {
        List<Lecture> lectures = new List<Lecture>();
        PaginationModel pagination = new PaginationModel
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
        };
        using (var call = _lectureClient.GetAllLectures(pagination))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentLecture = call.ResponseStream.Current;
                lectures.Add(currentLecture.AsBase());
            }
        }
        return lectures;
    }
}


   