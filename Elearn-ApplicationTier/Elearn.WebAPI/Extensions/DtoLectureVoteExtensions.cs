using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Shared.Extensions;

public static class DtoLectureVoteExtensions
{
    public static LectureVoteDto AsDto(this LectureVote lectureVote) 
    {
        return new LectureVoteDto
        {
            Username = lectureVote.User != null ? lectureVote.User.Username : String.Empty,
            LectureUrl = lectureVote.Lecture != null ? lectureVote.Lecture.Url : String.Empty,
            Upvote = lectureVote.Upvote
        };
    }

    public static LectureVote AsBase(this LectureVoteDto lectureVoteDto)
    {
        LectureVote lectureVote = new LectureVote
        {
            Upvote = lectureVoteDto.Upvote
        };
        
        lectureVote.Lecture = new Lecture();
        lectureVote.Lecture.Url = lectureVoteDto.LectureUrl;

        lectureVote.User = new User();
        lectureVote.User.Username = lectureVoteDto.Username;
        return lectureVote;
    }

    public static LectureVoteCounterDto AsLectureVoteCounterDto(this LectureVoteCounter lectureVoteCounter)
    {
        return new LectureVoteCounterDto
        {
            LectureUrl = lectureVoteCounter.Lecture != null ? lectureVoteCounter.Lecture.Url : String.Empty,
            UpvoteCount = lectureVoteCounter.upvoteCount,
            DownvoteCount = lectureVoteCounter.downvoteCount
        };
    }
    
}