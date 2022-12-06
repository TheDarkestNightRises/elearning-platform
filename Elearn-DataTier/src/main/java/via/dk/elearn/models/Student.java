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

    public Student(String username, String email, String name, String password, String image, String role, int security_level, University university, boolean approved) {
        super(username, email, name, password, image, role, security_level, university, approved);
    }

    public Student(String username, String email, String name, String password, String role, int security_level, boolean approved) {
        super(username, email, name, password, role, security_level, approved);
    }
}
