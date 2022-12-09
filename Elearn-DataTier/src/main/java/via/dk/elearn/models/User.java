package via.dk.elearn.models;


import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.SuperBuilder;

import javax.persistence.*;

@Entity
@Data
@Inheritance(strategy = InheritanceType.JOINED)
@SuperBuilder
@NoArgsConstructor
@AllArgsConstructor
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

    @Lob
    @Column(name = "image")
    private String image;
//
//    @Column(name = "first_name", nullable = false)
//    private String firstName;
//
//    @Column(name = "last_name", nullable = false)
//    private String lastName;

    @Column(name = "role",nullable = false)
    private String role;

    @Column(name = "approved", nullable = false)
    private boolean approved;

    @Column(name = "security_level",nullable = false)
    private int security_level;
//
//    @Column(name = "user_photo")
//    private String user_photo;
//
    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "country_id")
    private Country country;

    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "university_id") /// Nullable??
    private University university;


    public User(String username, String email, String name, String password, String image, String role, boolean approved, int security_level, Country country, University university) {
        this.username = username;
        this.email = email;
        this.name = name;
        this.password = password;
        this.image = image;
        this.role = role;
        this.approved = approved;
        this.security_level = security_level;
        this.country = country;
        this.university = university;
    }

    @Override
    public String toString() {
        return "User{" +
                "id=" + id +
                ", username='" + username + '\'' +
                ", email='" + email + '\'' +
                ", name='" + name + '\'' +
                ", password='" + password + '\'' +
                ", image='" + image + '\'' +
                ", role='" + role + '\'' +
                ", approved=" + approved +
                ", security_level=" + security_level +
                ", university=" + university +
                '}';
    }


}
