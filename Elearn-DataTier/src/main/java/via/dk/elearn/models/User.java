package via.dk.elearn.models;

import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.SuperBuilder;

import javax.persistence.*;

@Entity
@Data
@Inheritance(strategy = InheritanceType.JOINED)
@SuperBuilder
@NoArgsConstructor
public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column(unique = true, name = "username", nullable = false)
    private String username;

    @Column(unique = true, name = "email", nullable = false)
    private String email;

    @Column(unique = true, name = "name", nullable = false)
    private String name;

    @Column(name = "password", nullable = false)
    private String password;
//
//    @Column(name = "first_name", nullable = false)
//    private String firstName;
//
//    @Column(name = "last_name", nullable = false)
//    private String lastName;

    @Column(name = "role",nullable = false)
    private String role;

    @Column(name = "security_level",nullable = false)
    private int security_level;
//
//    @Column(name = "user_photo")
//    private String user_photo;
//
//    @ManyToOne(fetch = FetchType.LAZY)
//    @JoinColumn(name = "country_id")
//    private Country country;
//
//    @ManyToOne(fetch = FetchType.LAZY)
//    @JoinColumn(name = "university_id") /// Nullable??
//    private University university;

    public User(Long id, String username, String email, String name, String password, String role, int security_level) {
        this.id = id;
        this.username = username;
        this.email = email;
        this.name = name;
        this.password = password;
        this.role = role;
        this.security_level = security_level;
    }

    public User(String username, String email, String name, String password, String role, int security_level) {
        this.username = username;
        this.email = email;
        this.name = name;
        this.password = password;
        this.role = role;
        this.security_level = security_level;
    }

    @Override
    public String toString() {
        return "User{" +
                "id=" + id +
                ", username='" + username + '\'' +
                ", email='" + email + '\'' +
                ", name='" + name + '\'' +
                ", password='" + password + '\'' +
                ", role='" + role + '\'' +
                ", security_level=" + security_level +
                '}';
    }
}
