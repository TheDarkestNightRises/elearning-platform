package via.dk.elearn.models;

import lombok.Data;

import javax.persistence.*;

@Entity
@Data

public class Moderator {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;
}
