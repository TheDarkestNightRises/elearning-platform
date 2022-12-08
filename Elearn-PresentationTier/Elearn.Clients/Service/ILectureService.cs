

using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.HttpClients.Service;

public interface ILectureService
{
    Task<LectureDto> CreateAsync(LectureCreationDto dto);
    Task<List<LectureDto>> GetLecturesAsync();
    Task<List<LectureDto>> GetLecturesAsync(int pageNumber, int pageSize);
    Task<LectureDto?> GetLectureByUrlAsync(string url);
    Task<List<LectureDto>> GetLectureByTeacherIdAsync(long userId);
    Task<List<LectureDto>> GetUpvotedLectureByUserIdAsync(long userId);
    Task<List<LectureDto?>> GetLecturesByUniversity(long universityId);
    Task UpdateLecture(LectureUpdateDto updateDto);

}