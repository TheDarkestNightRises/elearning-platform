package via.dk.elearn.seed;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;
import via.dk.elearn.models.Country;
import via.dk.elearn.models.Teacher;
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

    }
}
