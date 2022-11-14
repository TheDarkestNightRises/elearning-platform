package via.dk.elearn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.dk.elearn.entity.Country;

@Repository
public interface CountryRepository extends JpaRepository<Country,Long> {
}
