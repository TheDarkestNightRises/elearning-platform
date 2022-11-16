package via.dk.elearn.models;

import lombok.Data;

import javax.persistence.*;

@Entity
@Data
public class Course {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column(name = "course_name", length = 30)
    private String courseName;
}
