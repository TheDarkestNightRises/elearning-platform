package via.dk.elearn.models;

import lombok.Data;

import javax.persistence.*;
import java.util.Date;

@Entity
@Data
public class Lecture {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column(name = "title", length = 50)
    private String title;

    @Column(name = "description", length = 80)
    private String description;

    @Column(unique = true, name = "url")
    private String url;

    @Lob
    @Column(name = "body")
    private String body;

    @Lob
    @Column(name = "image")
    private String image;

    @Column
    @Temporal(TemporalType.DATE)
    private Date published_date;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "course_id")
    private Course course;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "teacher_id", nullable = false)
    private Teacher teacher;



    public Lecture(String title, String description, String url,String image) {
        this.title = title;
        this.description = description;
        this.url = url;
        this.body = body;
        this.image = image;
    }

    public Lecture() {

    }
}
