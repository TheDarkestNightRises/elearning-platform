using Elearn.Shared.Dtos;

namespace Elearn.HttpClients.Service;

public interface ILectureVoteService
{
    Task<LectureVoteDto> CreateAsync(LectureVoteDto dto);
    Task<LectureVoteDto> GetByIdAsync(string username, string url);
    Task<LectureVoteCounterDto> GetVoteCounter(string url);
}