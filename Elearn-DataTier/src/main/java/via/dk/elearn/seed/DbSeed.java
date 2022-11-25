package via.dk.elearn.seed;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;
import via.dk.elearn.models.*;
import via.dk.elearn.repository.*;

import java.time.LocalDate;
import java.util.Date;

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

        if (countryRepository.count() > 0) return;// if there are no countries, no other entity can be created

        //add countries
        Country country1 = new Country();
        country1.setCountryName("Denmark");
        Country createdCountry1 = countryRepository.save(country1);

        //add teachers
        Teacher teacher1 = new Teacher("oriana","email","Oriana Cinimo Amadeo","ihatenes","teacher",3);
        Teacher createdTeacher1 = teacherRepository.save(teacher1);

        //add courses
        Course course1 = new Course();
        course1.setCourseName("Java Basics");
        Course createdCourse1 = courseRepository.save(course1);

        //add lectures
        Lecture lecture1 = new Lecture();
        lecture1.setTitle("Lesson 1");
        lecture1.setBody("Lorem ipsum random text that I just wrote why is this taking so long");
        lecture1.setDescription("Java is a cool language");
        lecture1.setPublished_date(LocalDate.of(2020, 12, 12));
        lecture1.setImage("placeholder string");
        lecture1.setCourse(createdCourse1);
        lecture1.setTeacher(createdTeacher1);
        lecture1.setUrl("url");
        Lecture createdlecture1 = lectureRepository.save(lecture1);
    }
}
