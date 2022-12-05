package via.dk.elearn.models;

import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.SuperBuilder;

import javax.persistence.*;

@Entity
@Data
@NoArgsConstructor
@SuperBuilder
public class Moderator extends User{
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    public Moderator(String username, String email, String name, String password, String image, String role, int security_level, University university, boolean approved) {
        super(username, email, name, password, image, role, security_level, university, approved);
    }

    public Moderator(String username, String email, String name, String password, String role, int security_level, boolean approved) {
        super(username, email, name, password, role, security_level, approved);
    }
}
