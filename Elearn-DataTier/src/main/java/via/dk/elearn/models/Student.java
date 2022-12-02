package via.dk.elearn.models;

import lombok.Data;

import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;

@Entity
@Data
public class Student extends User{

    public Student() {
    }

    public Student(Long id, String username, String email, String name, String password, String image, String role, int security_level, University university) {
        super(id, username, email, name, password, image, role, security_level, university);
    }

    public Student(String username, String email, String name, String password, String image, String role, int security_level, University university) {
        super(username, email, name, password, image, role, security_level, university);
    }
}
