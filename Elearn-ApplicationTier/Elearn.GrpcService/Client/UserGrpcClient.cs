using Elearn.Application.ServiceContracts;
using ElearnGrpc;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Post = Elearn.Shared.Models.Post;
using User = Elearn.Shared.Models.User;

namespace Elearn.GrpcService.Client;

public class UserGrpcClient : IUserService
{
    private ElearnGrpc.User.UserClient _userClient;
    
    
    public UserGrpcClient()
    {
        var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
        var _grpcChannel =
            GrpcChannel.ForAddress("https://localhost:8080", new GrpcChannelOptions { HttpClient = httpClient });
        _userClient = new ElearnGrpc.User.UserClient(_grpcChannel);
    }
    public Task<User?> GetUserByNameAsync(string name)
    {
        throw new NotImplementedException();

    }

    public Task<User> CreateNewUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserByIdAsync(int id)
    {
        var userRequested = new UserLookupModel { Id = id };
        var userFromGrpc = _userClient.GetUser(userRequested);
        User user = new User
        {
            UserId = userFromGrpc.Id,
            Username = userFromGrpc.Username,
            Email = userFromGrpc.Email,
            
        };
        return post;
    }
}