using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Extensions;
using Elearn.Shared.Models;
using ElearnGrpc;
using Grpc.Core;

namespace Elearn.GrpcService.Client;

public class StudentGrpcClient : IStudentService
{
    private StudentService.StudentServiceClient _studentClient;

    public StudentGrpcClient()
    {
        var _grpcChannel =
            new Channel("localhost:8843", ChannelCredentials.Insecure);
        _studentClient = new StudentService.StudentServiceClient(_grpcChannel);
    }
    public async Task<Student> GetStudentByUsernameAsync(string username)
    {
        var studentRequested = new StudentUsername() { Username = username };
        var studentFromGrpc = await _studentClient.getStudentByUsernameAsync(studentRequested);
        return studentFromGrpc.AsBase();
    }
}