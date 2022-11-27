namespace Elearn.Shared.Dtos;

public class LectureVoteCounterDto
{
    public string LectureUrl { set; get; }
    public long upvoteCount{ set; get; }
    public long downvoteCount{ set; get; }

    public LectureVoteCounterDto(string lectureUrl, long upvoteCount, long downvoteCount)
    {
        LectureUrl = lectureUrl;
        this.upvoteCount = upvoteCount;
        this.downvoteCount = downvoteCount;
    }
}