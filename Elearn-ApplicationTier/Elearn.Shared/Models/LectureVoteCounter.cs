namespace Elearn.Shared.Models;

public class LectureVoteCounter
{
    public Lecture Lecture { set; get; }
    public long upvoteCount{ set; get; }
    public long downvoteCount{ set; get; }

    public LectureVoteCounter(Lecture lecture, long upvoteCount, long downvoteCount)
    {
        Lecture = lecture;
        this.upvoteCount = upvoteCount;
        this.downvoteCount = downvoteCount;
    }
}