package via.dk.elearn.seed;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;
import via.dk.elearn.entity.Country;
import via.dk.elearn.entity.Teacher;
import via.dk.elearn.repository.CountryRepository;
import via.dk.elearn.repository.TeacherRepository;

@Component
public class TeacherSeed implements CommandLineRunner {

    @Autowired
    TeacherRepository repo;
    @Autowired
    CountryRepository countryRepository;

    @Override
    public void run(String... args) throws Exception {
        if (repo.count() > 0) return;
        Country country = new Country();
        country.setCountryName("Denmark");
        Country created = countryRepository.save(country);
        Teacher teacher = new Teacher("user", "gggg@sfus.3w4", "passsdd", "asfaf", "ajsnsa", created, 123l, "yes","Teacher");
        repo.save(teacher);
    }
}
