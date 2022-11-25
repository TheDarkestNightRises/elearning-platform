package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.dk.elearn.models.Teacher;

import java.util.List;

@Repository
public interface TeacherRepository  extends JpaRepository<Teacher,Long> {
    List<Teacher> findByUsername(String username);
}
