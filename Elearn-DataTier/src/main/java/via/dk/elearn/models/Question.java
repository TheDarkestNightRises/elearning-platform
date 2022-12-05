package via.dk.elearn.models;

import lombok.Builder;
import lombok.Data;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import javax.persistence.*;

@Entity
@Data
@Builder
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

    @Column(name = "url")
    private String url;

    //TODO: Does question have course?
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "course_id")
    @OnDelete(action = OnDeleteAction.CASCADE)
    private Course course;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "user_id")
    @OnDelete(action = OnDeleteAction.CASCADE)

    private User user;

    public Question(String body, String title, String url) {
        this.body = body;
        this.title = title;
        this.url = url;
    }

    public Question() {

    }

    public String toString() {
        return "Question: " + title + " " + body + " " + url;
    }

    public Question(Long id, String title, String description, String body, String url, Course course, User user) {
        this.id = id;
        this.title = title;
        this.description = description;
        this.body = body;
        this.url = url;
        this.course = course;
        this.user = user;
    }
}
