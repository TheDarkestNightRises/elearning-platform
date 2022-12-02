package via.dk.elearn.models;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.SuperBuilder;

import javax.persistence.*;

@Entity
@Data
@NoArgsConstructor
@SuperBuilder
public class Teacher extends User{
    public Teacher(Long id, String username, String email, String name, String password, String image, String role, int security_level, University university) {
        super(id, username, email, name, password, image, role, security_level, university);
    }

    public Teacher(String username, String email, String name, String password, String image, String role, int security_level, University university) {
        super(username, email, name, password, image, role, security_level, university);
    }
}
