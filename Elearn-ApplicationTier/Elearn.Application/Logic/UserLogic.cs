﻿using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Application.Logic;

public class UserLogic : IUserLogic
{

    private readonly IUserService _userService;

    public UserLogic(IUserService userService)
    {
        _userService = userService;
    }
    

    public async Task<User> UpdateUserAsync(UpdateUserDto dto)
    {
        User? user = await _userService.GetUserByNameAsync(dto.Name);
         Console.Write(user);
         if (user == null)
         {
             throw new Exception($"User with name {dto.Name} was not found.");
         }
         var updated = user;
         updated.Password = dto.Password;
         updated.Email = dto.Email;
         await _userService.UpdateUserAsync(updated);
         return updated;
    }
}