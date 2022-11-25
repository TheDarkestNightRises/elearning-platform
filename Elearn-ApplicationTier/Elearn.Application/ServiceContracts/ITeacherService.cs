using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface ITeacherService
{
    Task<Teacher?> GetTeacherByUsernameAsync(string username);
}