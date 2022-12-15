package via.dk.elearn.models;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Entity
@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class University {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column(unique = true, name = "university_name", length = 100)
    private String universityName;

    @Column(unique = true, name = "description", length = 1000)
    private String description;

    public University(String universityName, String description) {
        this.universityName = universityName;
        this.description = description;
    }
}
