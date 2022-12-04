package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.dk.elearn.models.Moderator;
import via.dk.elearn.models.Teacher;

import java.util.List;

@Repository
public interface ModeratorRepository  extends JpaRepository<Moderator,Long> {
    List<Moderator> findByUsername(String username);

}
