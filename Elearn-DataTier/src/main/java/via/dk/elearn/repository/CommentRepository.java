package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.dk.elearn.entity.Comment;

@Repository
public interface CommentRepository extends JpaRepository<Comment,Long> {
}
