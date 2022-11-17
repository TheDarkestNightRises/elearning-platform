package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.dk.elearn.CompositePKs.LectureVoteId;
import via.dk.elearn.models.LectureVote;

@Repository
public interface LectureVoteRepository extends JpaRepository<LectureVote, LectureVoteId> {
}
