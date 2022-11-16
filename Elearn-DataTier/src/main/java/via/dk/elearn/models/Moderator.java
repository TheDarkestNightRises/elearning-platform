package via.dk.elearn.models;

import lombok.Data;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
@Data
public class Moderator {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;
}
