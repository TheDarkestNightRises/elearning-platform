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
    private CommentRepository commentRepository;
    private CountryRepository countryRepository;

    private CourseRepository courseRepository;
    private LectureRepository lectureRepository;
    private LectureVoteRepository lectureVoteRepository;
    private ModeratorRepository moderatorRepository;
    private QuestionRepository questionRepository;
    private StudentRepository studentRepository;
    private TeacherRepository teacherRepository;
    private UniversityRepository universityRepository;
    private UserRepository userRepository;

    @Autowired
    public DbSeed(CommentRepository commentRepository, CountryRepository countryRepository, CourseRepository courseRepository, LectureRepository lectureRepository, LectureVoteRepository lectureVoteRepository, ModeratorRepository moderatorRepository, QuestionRepository questionRepository, StudentRepository studentRepository, TeacherRepository teacherRepository, UniversityRepository universityRepository, UserRepository userRepository) {
        this.commentRepository = commentRepository;
        this.countryRepository = countryRepository;
        this.courseRepository = courseRepository;
        this.lectureRepository = lectureRepository;
        this.lectureVoteRepository = lectureVoteRepository;
        this.moderatorRepository = moderatorRepository;
        this.questionRepository = questionRepository;
        this.studentRepository = studentRepository;
        this.teacherRepository = teacherRepository;
        this.universityRepository = universityRepository;
        this.userRepository = userRepository;
    }

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

        //add students
        Student student = new Student("Dexter","email2","Dexter Morgan","bloodanalyst","student",1);
        Student createdStudent = studentRepository.save(student);

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

        //add questions
        Question question = new Question();
        question.setTitle("How to run npm with vite?");
        question.setBody("I tried to use vite but I dont know how to run the project");
        question.setUrl("npm-doenst-work");
        question.setDescription("Please help");
        question.setUser(createdStudent);
        Question createdQuestion = questionRepository.save(question);
    }
}
