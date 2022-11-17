package via.dk.elearn.models;

import lombok.Data;
import via.dk.elearn.CompositePKs.LectureVoteId;

import javax.persistence.*;

@Entity
@Data
@IdClass(LectureVoteId.class)
public class LectureVote {

    @Id
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "teacher_id", nullable = false)
    private Teacher teacher;

    @Id
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "lecture_id", nullable = false)
    private Lecture lecture;

    @Column(nullable = false)
    private boolean upvote;//true = upvote, false = downvote
}
