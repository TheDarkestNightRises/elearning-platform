package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.LectureVoteId;
import via.dk.elearn.models.LectureVote;

import java.util.List;

@Repository
public interface LectureVoteRepository extends JpaRepository<LectureVote, LectureVoteId> {
    Long countLectureVotesByUpvoteEqualsAndLectureEquals(boolean vote, Lecture lecture);//
}
