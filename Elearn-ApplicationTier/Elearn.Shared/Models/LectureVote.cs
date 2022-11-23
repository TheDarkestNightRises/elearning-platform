namespace Elearn.Shared.Models;

public class LectureVote
{
    public User User { get; set; }
    public Lecture Lecture { get; set; }
    public bool Upvote { get; set; }

    public LectureVote(User user, Lecture lecture, bool upvote)
    {
        User = user;
        Lecture = lecture;
        Upvote = upvote;
    }
}