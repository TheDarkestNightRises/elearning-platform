namespace Elearn.Application.LogicInterfaces;

public interface IUserLogic
{
    Task ChangePasswordAsync(long id, string password);
}