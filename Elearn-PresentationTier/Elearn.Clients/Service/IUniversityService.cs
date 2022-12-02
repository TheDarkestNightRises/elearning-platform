using Elearn.Shared.Dtos;

namespace Elearn.HttpClients.Service;

public interface IUniversityService
{
    Task<List<UniversityDto>> GetAllUniveritiesAsync();
}