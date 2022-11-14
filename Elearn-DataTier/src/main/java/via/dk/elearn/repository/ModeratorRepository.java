package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.dk.elearn.entity.Moderator;

@Repository
public interface ModeratorRepository  extends JpaRepository<Moderator,Long> {
}
