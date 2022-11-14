package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.dk.elearn.entity.Lecture;

@Repository
public interface LectureRepository  extends JpaRepository<Lecture,Long> {
}
