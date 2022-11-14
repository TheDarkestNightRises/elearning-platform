package via.dk.elearn.entity;

import lombok.Data;

import javax.persistence.*;

@Entity
@Data
public class Country {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column(unique = true, name = "country_name", length = 100)
    private String countryName;
}
