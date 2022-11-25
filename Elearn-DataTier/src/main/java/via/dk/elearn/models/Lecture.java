package via.dk.elearn.models;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;

import javax.persistence.*;
import java.time.LocalDate;
import java.util.Date;

@Entity
@Data
@Builder
@AllArgsConstructor
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

    private LocalDate published_date;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "course_id")
    private Course course;

    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "teacher_id")
    private Teacher teacher;





    public Lecture() {

    }

    public Lecture(String title, String url, String image, String body) {
        this.title = title;
        this.url = url;
        this.image = image;
        this.body = body;
    }
}
