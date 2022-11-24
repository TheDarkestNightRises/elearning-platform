package via.dk.elearn.models;

import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Entity
@Data
@NoArgsConstructor

public class Teacher extends User{

    public Teacher(String username, String email, String name, String password, String role, int security_level) {
        super(username, email, name, password, role, security_level);
    }
}
