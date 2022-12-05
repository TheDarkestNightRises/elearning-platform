using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface IModeratorService
{
    Task<Moderator?> GetModeratorByUsernameAsync(string username);

}