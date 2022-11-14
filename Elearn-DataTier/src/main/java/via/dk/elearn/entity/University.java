package via.dk.elearn.entity;

import lombok.Data;

import javax.persistence.*;

@Entity
@Data
public class University {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column(unique = true, name = "university_name", length = 100)
    private String universityName;
}
