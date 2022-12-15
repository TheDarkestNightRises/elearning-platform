package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.dk.elearn.models.Question;

import java.util.List;

@Repository
public interface QuestionRepository extends JpaRepository<Question,Long> {
    List<Question> findByUrl(String url);

    List<Question> findByTitleContaining(String title);

    List<Question> getQuestionByStudentId(long studentId);
}
