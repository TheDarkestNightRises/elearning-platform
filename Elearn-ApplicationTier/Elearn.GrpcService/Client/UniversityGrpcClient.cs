using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Extensions;
using Elearn.Shared.Models;
using ElearnGrpc;
using Grpc.Core;

namespace Elearn.GrpcService.Client;

public class UniversityGrpcClient : IUniversityService
{
    private UniversityService.UniversityServiceClient _universityClient;

    public UniversityGrpcClient()
    {
        var _grpcChannel = new Channel("localhost:8843", ChannelCredentials.Insecure);
        _universityClient = new UniversityService.UniversityServiceClient(_grpcChannel);
    }

    public async Task<List<Lecture>> GetAllLecturesByUniversity(University university)
    {
        List<Lecture> lectures = new List<Lecture>();
        using (var call = _universityClient.GetLecturesByUniversity(university.AsGrpcModel()))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentLecture = call.ResponseStream.Current;
                lectures.Add(currentLecture.AsBase());
            }
        }

        return lectures;
    }

    public async Task<List<University>> GetAllUniversities()
    {
        List<University> universities = new List<University>();
        using (var call = _universityClient.GetUniversities(new UniversityRequest()))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentUniversity = call.ResponseStream.Current;
                universities.Add(currentUniversity.AsBase());
            }
        }
        return universities;
    }

    public async Task<University> GetUniversityById(long id)
    {
        var universityId = new UniversityId() { Id = id };
        var universityGrpcModel = await _universityClient.GetUniversityByIdAsync(universityId);
        return universityGrpcModel.AsBase();
    }
}