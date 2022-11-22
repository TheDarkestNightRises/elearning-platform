namespace Elearn.Shared.Models;

public class LectureVoteCounter
{
    public Post Post { set; get; }
    public long upvoteCount{ set; get; }
    public long downvoteCount{ set; get; }

    public LectureVoteCounter(Post post, long upvoteCount, long downvoteCount)
    {
        Post = post;
        this.upvoteCount = upvoteCount;
        this.downvoteCount = downvoteCount;
    }
}