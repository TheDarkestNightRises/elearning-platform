

using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.HttpClients.Service;

public interface ILectureService
{
    Task<LectureDto> CreateAsync(LectureCreationDto dto);
    Task<List<LectureDto>> GetLecturesAsync();
    Task<LectureDto?> GetLectureByUrlAsync(string url);
    Task<LectureDto?> GetLectureByUserIdAsync(int userId);
}