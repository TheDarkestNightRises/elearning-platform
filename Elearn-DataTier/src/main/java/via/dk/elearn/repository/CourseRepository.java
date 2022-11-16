package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.dk.elearn.models.Course;

@Repository
public interface CourseRepository extends JpaRepository<Course,Long> {
}
