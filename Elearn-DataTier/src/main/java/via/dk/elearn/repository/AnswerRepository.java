package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import via.dk.elearn.models.Answer;

public interface AnswerRepository extends JpaRepository<Answer,Long> {
}
