package via.dk.elearn.CompositePKs;

import lombok.Data;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.Teacher;

import java.io.Serializable;
import java.util.Objects;

@Data
public class LectureVoteId implements Serializable {

    private Long teacher;
    private Long lecture;




}
