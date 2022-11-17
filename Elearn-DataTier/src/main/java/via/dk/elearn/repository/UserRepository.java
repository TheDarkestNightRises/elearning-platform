package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import via.dk.elearn.models.User;

import java.util.List;

@Repository
public interface UserRepository  extends JpaRepository<User,Long> {
    @Query(value = "SELECT * FROM user u WHERE u.username = :username", nativeQuery = true)
    List<User> findByUsername(String username);


}
