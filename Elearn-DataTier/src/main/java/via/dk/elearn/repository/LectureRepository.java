package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.Teacher;
import via.dk.elearn.models.University;
import via.dk.elearn.protobuf.UserId;

import java.util.List;

@Repository
public interface LectureRepository  extends JpaRepository<Lecture,Long> {
    List<Lecture> findByUrl(String url);

    @Query(value = "SELECT * FROM lecture l WHERE l.id IN (SELECT lecture_id FROM lecture_vote lv WHERE user_id = :userId AND lv.upvote = true)", nativeQuery = true)
    List<Lecture> findUpvotedLecturesOfUser(Long userId);

    List<Lecture> findByTitleContaining(String title);

   // @Query(value = "SELECT * FROM lecture l WHERE l.id IN (SELECT lecture_id WHERE user_id = :userId)", nativeQuery = true)
    List<Lecture> findUserLecturesById(long userId);

    List<Lecture> findAllByTeacher_University(University university);
}

