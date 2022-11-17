package via.dk.elearn.entity;

import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Entity
@Data
@NoArgsConstructor
public class Teacher extends User{
    @Column
    private Long teacher_test_property;

    @Column
    private String verified;

    public Teacher(String username, String email, String password, String firstName, String lastName, Country country, Long teacher_test_property, String verified, String role) {
        super(username, email, password, firstName, lastName, country,role);
        this.teacher_test_property = teacher_test_property;
        this.verified = verified;
    }
}
