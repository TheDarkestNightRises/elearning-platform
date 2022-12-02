package via.dk.elearn.models;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import java.time.LocalDate;
import java.util.Date;

@Entity
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class Comment {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column(name = "text", length = 200)
    private String text;

    @Column
    private LocalDate published_date;

    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "lecture_id")
    private Lecture lecture;

    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "user_id", nullable = false)
    private User user;



    public Comment(String text, LocalDate published_date, Lecture lecture, User user) {
        this.text = text;
        this.published_date = published_date;
        this.lecture = lecture;
        this.user = user;
    }
}
