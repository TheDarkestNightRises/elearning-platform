namespace Elearn.Shared.Dtos;

public class LectureVoteCounterDto
{
    public string LectureUrl { set; get; }
    public long UpvoteCount{ set; get; }
    public long DownvoteCount{ set; get; }

    public LectureVoteCounterDto(string lectureUrl, long upvoteCount, long downvoteCount)
    {
        LectureUrl = lectureUrl;
        this.UpvoteCount = upvoteCount;
        this.DownvoteCount = downvoteCount;
    }

    public LectureVoteCounterDto()
    {
        
    }
}