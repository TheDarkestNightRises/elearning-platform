using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Extensions;
using Elearn.Shared.Models;
using ElearnGrpc;
using Grpc.Core;

namespace Elearn.GrpcService.Client;

public class TeacherGrpcClient : ITeacherService
{
    private TeacherService.TeacherServiceClient _userClient;

    public TeacherGrpcClient()
    {
        var _grpcChannel =
            new Channel("localhost:8843", ChannelCredentials.Insecure);
        _userClient = new TeacherService.TeacherServiceClient(_grpcChannel);
    }
    
    public async Task<Teacher?> GetTeacherByUsernameAsync(string username)
    {
        var teacherRequested = new UserName { Username = username };
        var teacherFromGrpc = await _userClient.getTeacherByUsernameAsync(teacherRequested);
        return teacherFromGrpc.AsBase();
    }

}