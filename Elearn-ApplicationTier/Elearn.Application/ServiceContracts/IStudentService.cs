using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface IStudentService
{
    Task<Student> GetStudentByUsernameAsync(string username);
}