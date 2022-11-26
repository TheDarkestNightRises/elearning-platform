using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Models;

namespace Elearn.Application.Logic;

public class LectureVoteLogic : ILectureVoteLogic
{
    private readonly ILectureService _lectureService;
    private readonly IUserService _userService;
    private readonly ILectureVoteService _lectureVoteService;

    public LectureVoteLogic(ILectureService lectureService, IUserService userService, ILectureVoteService lectureVoteService)
    {
        _lectureService = lectureService;
        _userService = userService;
        _lectureVoteService = lectureVoteService;
    }
    public async Task<LectureVote> CreateLectureVoteAsync(LectureVote lectureVote)
    {
        if (lectureVote.User is null)
        {
            throw new Exception("Invalid request: user not present in request");
        }
        User? user = await _userService.GetUserByUsernameAsync(lectureVote.User.Username);
        if (user is null)
        {
            throw new Exception("User not found in database");
        }
        
        if (lectureVote.Lecture is null)
        {
            throw new Exception("Invalid request: lecture not present in request");
        }
        Lecture? lecture = await _lectureService.GetPostAsync(lectureVote.Lecture.Url);
        if (lecture is null)
        {
            throw new Exception("Lecture not found in database");
        }

        if (lectureVote.Upvote is null)
        {
            throw new Exception("Vote type not set");
        }
        LectureVote lectureVoteRequest = new LectureVote(user, lecture, lectureVote.Upvote);
        return await _lectureVoteService.CreateLectureVoteAsync(lectureVoteRequest);
    }

    public async Task<LectureVoteCounter> GetLectureVotesCountAsync(Lecture post)
    {
        return await _lectureVoteService.GetLectureVotesCountAsync(post);
    }

    public async Task<LectureVote> GetLectureVotebyIdAsync(User user, Lecture post)
    {
        Lecture? requestedLecture = await _lectureService.GetPostAsync(post.Url);
        User? requestedUser = await _userService.GetUserByUsernameAsync(user.Username);
        if (requestedLecture is null || requestedUser is null)
        {
            throw new Exception("Invalid request: user or lecture not found");
        }
        
        LectureVote lectureVote = await _lectureVoteService.GetLectureVotebyIdAsync(user, post);

        return await _lectureVoteService.GetLectureVotebyIdAsync(requestedUser, requestedLecture);
    }
}