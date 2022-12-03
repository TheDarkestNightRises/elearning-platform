package via.dk.elearn.models;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import java.time.LocalDate;

@Entity
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
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
    private LocalDate date;

    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "course_id")
    private Course course;

    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "teacher_id")
    private Teacher teacher;

    public Lecture(String title, String url, String image, String body) {
        this.title = title;
        this.url = url;
        this.image = image;
        this.body = body;
    }

    public Lecture(String title, String description, String url, String body, String image, LocalDate date, Course course, Teacher teacher) {
        this.title = title;
        this.description = description;
        this.url = url;
        this.body = body;
        this.image = image;
        this.date = date;
        this.course = course;
        this.teacher = teacher;
    }
}
