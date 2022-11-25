package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import via.dk.elearn.models.Question;

import java.util.List;

@Repository
public interface QuestionRepository extends JpaRepository<Question,Long> {
    @Query(value = "SELECT * FROM question q WHERE q.url = :url", nativeQuery = true)
    List<Question> findByUrl(String url);

    List<Question> findByTitleContaining(String title);
}
