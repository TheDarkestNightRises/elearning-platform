namespace Elearn.Shared.Dtos;

public class LectureVoteIdDto
{
    public string Username { get; set; }
    public string LectureUrl { get; set; }

    public LectureVoteIdDto(string username, string lectureUrl)
    {
        Username = username;
        LectureUrl = lectureUrl;
    }
}