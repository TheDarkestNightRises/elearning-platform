using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Extensions;
using Elearn.Shared.Models;
using Grpc.Core;

namespace Elearn.GrpcService.Client;

public class ModeratorGrpcClient : IModeratorService
{
    private ModeratorService.ModeratorServiceClient _userClient;

    public ModeratorGrpcClient()
    {
        var _grpcChannel =
            new Channel("localhost:8843", ChannelCredentials.Insecure);
        _userClient = new ModeratorService.ModeratorServiceClient(_grpcChannel);
    }
    public async Task<Moderator?> GetModeratorByUsernameAsync(string username)
    {
        var moderatorRequested = new ModeratorUsername { Username = username };
        var moderatorFromGrpc = await _userClient.getModeratorByUsernameAsync(moderatorRequested);
        return moderatorFromGrpc.AsBase();    }
}