using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface ILectureVoteService
{
    public Task<LectureVote> CreateLectureVoteAsync(LectureVote lectureVote);
    public Task<LectureVoteCounter> GetLectureVotesCountAsync(Lecture post);
    public Task<LectureVote> GetLectureVotebyIdAsync(User user, Lecture post);
}