package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.dk.elearn.entity.Teacher;

@Repository
public interface TeacherRepository  extends JpaRepository<Teacher,Long> {
}
