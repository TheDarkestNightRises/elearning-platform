package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.dk.elearn.models.Student;

@Repository
public interface StudentRepository  extends JpaRepository<Student,Long> {
}
