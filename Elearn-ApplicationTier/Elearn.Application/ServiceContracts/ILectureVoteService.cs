using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface ILectureVoteService
{
    public Task<LectureVote> CreateLectureVoteAsync(LectureVote lectureVote);
    public Task<LectureVoteCounter> GetLectureVotesCountAsync(Post post);
    public Task<LectureVote> GetLectureVotebyIdAsync(User user, Post post);
}