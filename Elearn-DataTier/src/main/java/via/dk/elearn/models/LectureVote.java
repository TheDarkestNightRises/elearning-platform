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
    @JoinColumn(name = "user_id", nullable = false)
    private User user;

    @Id
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "lecture_id", nullable = false)
    private Lecture lecture;

    @Column(nullable = false)
    private boolean vote;
}
