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

    public Teacher(String username, String email, String password, String firstName, String lastName, Long teacher_test_property, String role) {
        super(username, email, password, firstName, lastName, role);
        this.teacher_test_property = teacher_test_property;
    }
}
