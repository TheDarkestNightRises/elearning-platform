package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.dk.elearn.entity.User;

@Repository
public interface UserRepository  extends JpaRepository<User,Long> {
}
