using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface ILectureVoteLogic
{
    public Task<LectureVote> CreateLectureVoteAsync(LectureVote lectureVote);
    public Task<LectureVoteCounter> GetLectureVotesCountAsync(Lecture post);
    public Task<LectureVote> GetLectureVotebyIdAsync(string username, string url);
}