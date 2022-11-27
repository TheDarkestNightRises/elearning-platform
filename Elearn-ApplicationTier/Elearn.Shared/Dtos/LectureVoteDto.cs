namespace Elearn.Shared.Dtos;

public class LectureVoteDto
{
    public string Username { get; set; }
    public string LectureUrl { get; set; }
    public bool? Upvote { get; set; }

    public LectureVoteDto(string username, string lectureUrl, bool? upvote)
    {
        Username = username;
        LectureUrl = lectureUrl;
        Upvote = upvote;
    }

    public LectureVoteDto()
    {
    }
}