package via.dk.elearn.CompositePKs;

import lombok.Data;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.User;

import java.io.Serializable;
import java.util.Objects;

@Data
public class LectureVoteId implements Serializable {

    private User user;
    private Lecture lecture;

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof LectureVoteId that)) return false;
        return user.getId().equals(that.user.getId()) && lecture.getId().equals(that.lecture.getId());
    }

    @Override
    public int hashCode() {
        return Objects.hash(user, lecture);
    }
}
