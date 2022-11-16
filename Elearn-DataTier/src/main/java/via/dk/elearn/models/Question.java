package via.dk.elearn.models;

import lombok.Data;

import javax.persistence.*;

@Entity
@Data
public class Question {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column(name = "title", length = 50)
    private String title;

    @Column(name = "description", length = 80)
    private String description;

    @Lob
    @Column(name = "body")
    private String body;

    //TODO: Does question have course?
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "course_id")
    private Course course;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "user_id", nullable = false)
    private User user;
}
