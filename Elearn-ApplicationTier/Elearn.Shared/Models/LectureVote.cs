namespace Elearn.Shared.Models;

public class LectureVote
{
    public User User { get; set; }
    public Post Post { get; set; }
    public bool Upvote { get; set; }

    public LectureVote(User user, Post post, bool upvote)
    {
        User = user;
        Post = post;
        Upvote = upvote;
    }
}