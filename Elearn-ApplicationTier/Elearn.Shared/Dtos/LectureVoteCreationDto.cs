namespace Elearn.Shared.Dtos;

public class LectureVoteCreationDto
{
     public string username { get; set; }
     public long lectureId { get; set; }
     public bool upvote { get; set; }
}