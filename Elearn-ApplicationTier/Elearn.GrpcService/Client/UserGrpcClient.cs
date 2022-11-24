﻿using Elearn.Application.ServiceContracts;
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
        var userRequested = new UserName { Name = name };
        var userFromGrpc = await _userClient.GetUserByNameAsync(userRequested);
        return userFromGrpc.AsBase();
    }

    public async Task<User> CreateNewUserAsync(User user)
    {
        var userModel = user.AsGrpcModel();
        var createdUserFromGrpc = await _userClient.CreateNewUserAsync(userModel);
        return createdUserFromGrpc.AsBase();
    }

    public async Task<User?> GetUserByIdAsync(int id)
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
}