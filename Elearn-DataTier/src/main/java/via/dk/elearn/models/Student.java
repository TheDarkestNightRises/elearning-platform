package via.dk.elearn.models;

import lombok.Data;
import lombok.experimental.SuperBuilder;

import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;

@Entity
@Data
@SuperBuilder
public class Student extends User{

    public Student() {
    }

    public Student(Long id, String username, String email, String name, String password, String image, String role, boolean approved, int security_level, Country country, University university) {
        super(id, username, email, name, password, image, role, approved, security_level, country, university);
    }

    public Student(String username, String email, String name, String password, String image, String role, boolean approved, int security_level, Country country, University university) {
        super(username, email, name, password, image, role, approved, security_level, country, university);
    }
}
