package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import via.dk.elearn.entity.Lecture;

import java.util.List;

@Repository
public interface LectureRepository  extends JpaRepository<Lecture,Long> {
    List<Lecture> findByUrl(String url);
}
