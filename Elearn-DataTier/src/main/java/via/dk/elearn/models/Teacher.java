package via.dk.elearn.models;

import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Entity
@Data
@NoArgsConstructor
public class Teacher extends User{
    @Column
    private Long teacher_test_property;

    public Teacher(String username, String email, String password, String firstName, String lastName, Country country, Long teacher_test_property) {
        super(username, email, password, firstName, lastName, country);
        this.teacher_test_property = teacher_test_property;
    }
}
