package via.dk.elearn.seed;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;
import via.dk.elearn.repository.*;

@Component
public class DbSeed implements CommandLineRunner {
    @Autowired
    CommentRepository commentRepository;
    @Autowired
    CountryRepository countryRepository;
    @Autowired
    CourseRepository courseRepository;
    @Autowired
    LectureRepository lectureRepository;
    @Autowired
    LectureVoteRepository lectureVoteRepository;
    @Autowired
    ModeratorRepository moderatorRepository;
    @Autowired
    QuestionRepository questionRepository;
    @Autowired
    StudentRepository studentRepository;
    @Autowired
    TeacherRepository teacherRepository;
    @Autowired
    UniversityRepository universityRepository;
    @Autowired
    UserRepository userRepository;

    @Override
    public void run(String... args) throws Exception {
        loadData();
    }

    private void loadData() {

    }
}
