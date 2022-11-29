package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import via.dk.elearn.models.Answer;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.Question;

import java.util.List;

public interface AnswerRepository extends JpaRepository<Answer, Long> {
    List<Answer> findAllByQuestion(Question question);
}
