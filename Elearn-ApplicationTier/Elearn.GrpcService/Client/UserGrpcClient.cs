using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Extensions;
using Elearn.Shared.Models;
using ElearnGrpc;
using Grpc.Core;
using Grpc.Net.Client;

namespace Elearn.GrpcService.Client;

public class UserGrpcClient : IUserService
{
    private UserService.UserServiceClient _userClient;

    public UserGrpcClient()
    {
        var _grpcChannel =
            new Channel("localhost:8843", ChannelCredentials.Insecure);
        _userClient = new UserService.UserServiceClient(_grpcChannel);
    }
    
    public async Task<User?> GetUserByNameAsync(string name)
    {
        var userRequested = new Name { Name_ = name};
        var userFromGrpc = await _userClient.GetUserByNameAsync(userRequested);
        return userFromGrpc.AsBase();
    }

   

    public async Task<User> CreateNewUserAsync(User user)
    {
        var userModel = user.AsGrpcModel();
        var universityModel = user.University is not null ? user.University.AsGrpcModel() : null;
        userModel.University = universityModel;
        var createdUserFromGrpc = await _userClient.CreateNewUserAsync(userModel);
        return createdUserFromGrpc.AsBase();
    }

    public async Task<User?> GetUserByIdAsync(long id)
    {
        var userRequested = new UserId { Id = id };
        var userFromGrpc = await _userClient.GetUserByIDAsync(userRequested);
        return userFromGrpc.AsBase();
    }

    public async Task<User> UpdateUserAsync(User updated)
    {
        var updatedModel = updated.AsGrpcModel();
        var updatedUserFromGrpc = await _userClient.UpdateUserAsync(updatedModel);
        return updatedUserFromGrpc.AsBase();
    }
    
    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        var userRequested = new UserName {  Username = username };
        var userFromGrpc = await _userClient.GetUserByUsernameAsync(userRequested);
        return userFromGrpc.AsBase();
    }
    
    public  async Task DeleteUserAsync(User user)
    {
        var userModel = user.AsGrpcModel();
        await _userClient.DeleteUserAsync(userModel);
    }
}