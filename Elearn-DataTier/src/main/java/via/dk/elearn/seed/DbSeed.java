package via.dk.elearn.seed;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;
import via.dk.elearn.models.*;
import via.dk.elearn.repository.*;

import java.time.LocalDate;
import java.util.Date;
import java.util.List;

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

        //add Universities
        University university1 = new University("VIA University College", "VIA is one of Denmark’s six university colleges. Programmes, courses and research focus on professional practice in areas such as healthcare, teaching, social education, technology, business and design.");
        University createdUniversity1 = universityRepository.save(university1);

        University university2 = new University("Aarhus University", "VIA is one of Denmark’s six university colleges. Programmes, courses and research focus on professional practice in areas such as healthcare, teaching, social education, technology, business and design.");
        University createdUniversity2 = universityRepository.save(university2);

        University university3 = new University("Aalborg University", "VIA is one of Denmark’s six university colleges. Programmes, courses and research focus on professional practice in areas such as healthcare, teaching, social education, technology, business and design.");
        University createdUniversity3 = universityRepository.save(university3);

        University university4 = new University("Dania Academy", "VIA is one of Denmark’s six university colleges. Programmes, courses and research focus on professional practice in areas such as healthcare, teaching, social education, technology, business and design.");
        University createdUniversity4 = universityRepository.save(university4);

        University university5 = new University("Copenhagen University College", "VIA is one of Denmark’s six university colleges. Programmes, courses and research focus on professional practice in areas such as healthcare, teaching, social education, technology, business and design.");
        University createdUniversity5 = universityRepository.save(university5);

        //add teachers
        Teacher teacher1 = new Teacher("oriana","email","Oriana Cinimo Amadeo","ihatenes", "placeholder string","teacher",3,createdUniversity1, true);

        Teacher createdTeacher1 = teacherRepository.save(teacher1);

        Teacher teacher2 = new Teacher("cosmin","email3","Cosmin Teodoru","password", "placeholder-string","teacher",3, createdUniversity2, true);
        Teacher createdTeacher2 = teacherRepository.save(teacher2);


        Moderator moderator = new Moderator("moderator","moderator@via.dk","Admin","Admin","placeholder-string","Moderator",10,createdUniversity1, true);
        Moderator createdModerator = moderatorRepository.save(moderator);

        //add students
        Student student = new Student("Dexter","email2","Dexter Morgan","bloodanalyst", "placeholder string","Student",1, createdUniversity1,false);
        Student createdStudent = studentRepository.save(student);

        //add courses
        Course course1 = new Course();
        course1.setCourseName("Java Basics");
        Course createdCourse1 = courseRepository.save(course1);

        //add lectures
        Lecture lecture1 = new Lecture("Lesson 1", "Java is a cool language", "url", "Lorem ipsum random text that I just wrote why is this taking so long", "placeholder string", LocalDate.of(2020, 12, 12), createdCourse1, createdTeacher1);
        Lecture createdlecture1 = lectureRepository.save(lecture1);

        Lecture lecture2 = new Lecture("Lesson 2", "Java is a cool language", "url2", "Lorem ipsum random text that I just wrote why is this taking so long", "placeholder string", LocalDate.of(2020, 12, 12), createdCourse1, createdTeacher1);
        Lecture createdlecture2 = lectureRepository.save(lecture2);

        Lecture lecture3 = new Lecture("Lesson 3", "Java is a cool language", "url3", "Lorem ipsum random text that I just wrote why is this taking so long", "placeholder string", LocalDate.of(2020, 12, 12), createdCourse1, createdTeacher2);
        Lecture createdlecture3 = lectureRepository.save(lecture3);

        //add questions
        Question question = new Question();
        question.setTitle("How to run npm with vite?");
        question.setBody("I tried to use vite but I dont know how to run the project");
        question.setUrl("npm-doenst-work");
        question.setDescription("Please help");
        question.setUser(createdStudent);
        Question createdQuestion = questionRepository.save(question);

        List<Lecture> lectures = lectureRepository.findAllByTeacher_University(createdUniversity2);

        for(int i = 0; i < lectures.size(); i++){
            System.out.println(lectures.get(i).getTitle());
        }

        LectureVote lectureVote = new LectureVote(createdTeacher1, createdlecture1, true);




    }
}
