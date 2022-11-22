package via.dk.elearn.models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.Teacher;

import java.io.Serializable;
import java.util.Objects;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class LectureVoteId implements Serializable {

    private Long user;
    private Long lecture;
}
