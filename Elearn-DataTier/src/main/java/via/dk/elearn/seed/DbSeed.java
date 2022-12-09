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
        Country country1 = new Country("Denmark");
        Country createdCountry1 = countryRepository.save(country1);

        Country country2 = new Country("Italy");
        Country createdCountry2 = countryRepository.save(country2);

        Country country3 = new Country("Romania");
        Country createdCountry3 = countryRepository.save(country3);

        Country country4 = new Country("Germany");
        Country createdCountry4 = countryRepository.save(country4);

        //add Universities
        University university1 = new University("VIA University College", "VIA is one of Denmark’s six university colleges. Programmes, courses and research focus on professional practice in areas such as healthcare, teaching, social education, technology, business and design.");
        University createdUniversity1 = universityRepository.save(university1);
        //https://en.via.dk/about-via
        University university2 = new University("Aarhus University", "Aarhus University in Denmark - a top 100 university with 50+ Master's and Bachelor's degree programmes in English. We have been achieving international excellence in research and education since 1928.");
        University createdUniversity2 = universityRepository.save(university2);
        //https://international.au.dk/
        University university3 = new University("University Of Padua", "The University of Padua is one of Europe’s oldest and most prestigious seats of learning; it is a multi-disciplinary university that aims to provide its students with both professional training and a solid cultural background.");
        University createdUniversity3 = universityRepository.save(university3);
        //https://www.mastersportal.com/universities/518/university-of-padua.html
        University university4 = new University("University of Bucharest", "The University of Bucharest offers study programmes in Romanian and English and is classified as an advanced research and education university by the Ministry of Education. In the 2012 QS World University Rankings, it was included in the top 700 universities of the world, together with three other Romanian universities.");
        University createdUniversity4 = universityRepository.save(university4);
        //https://en.wikipedia.org/wiki/University_of_Bucharest
        University university5 = new University("University of Copenhagen", "Founded in 1479, the University of Copenhagen is not only Denmark's oldest university, but also one of the oldest in Northern Europe. Its location in the capital city makes the University's development, key people and events part of the history of Denmark.");
        University createdUniversity5 = universityRepository.save(university5);
        //https://about.ku.dk/profile-history/history/

        //add teachers
        Teacher teacher1 = new Teacher("oriana","oriana@email.dk","Oriana Cinimo Amadeo","Password1234", "Placeholder","Teacher",true,4,createdCountry2,createdUniversity1);
        Teacher createdTeacher1 = teacherRepository.save(teacher1);

        Teacher teacher2 = new Teacher("cosmin","cosmin@email.com","Cosmin Teodoru","Cosmin1234", "Placeholder", "Teacher", true,4, createdCountry1, createdUniversity2);
        Teacher createdTeacher2 = teacherRepository.save(teacher2);

        //add moderators
        Moderator moderator = new Moderator("moderator","moderator@via.dk","Admin","Admin1234","placeholder-string","Moderator", true,10,createdCountry1, createdUniversity1);
        Moderator createdModerator = moderatorRepository.save(moderator);

        //add students
        Student student = new Student("dexter","email@host.dk","Dexter Morgan","Student1234", "placeholder string","Student",false, 2, createdCountry1,createdUniversity1);
        Student createdStudent = studentRepository.save(student);

        //add courses
        Course course1 = new Course();
        course1.setCourseName("Lorem Ipsum Course");
        Course createdCourse1 = courseRepository.save(course1);

        //add lectures
        Lecture lecture1 = new Lecture("Lorem Ipsum - part 1", "What is Lorem Ipsum", "lorem-ipsum-1", "LLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "placeholder string", LocalDate.of(2020, 12, 12), createdCourse1, createdTeacher1);
        Lecture createdlecture1 = lectureRepository.save(lecture1);
        //https://www.lipsum.com/

        Lecture lecture2 = new Lecture("Lorem Ipsum - part 2", "Why do we use Lorem Ipsum?", "lorem-ipsum-2", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", "placeholder string", LocalDate.of(2020, 12, 12), createdCourse1, createdTeacher1);
        Lecture createdlecture2 = lectureRepository.save(lecture2);
        //https://www.lipsum.com/
        Lecture lecture3 = new Lecture("Original Lorem Ipsum", "The standard Lorem Ipsum passage, used since the 1500s", "original-lorem-ipsum", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "placeholder string", LocalDate.of(2020, 12, 12), createdCourse1, createdTeacher2);
        Lecture createdlecture3 = lectureRepository.save(lecture3);
        //https://www.lipsum.com/
        //add questions

        Question question = new Question("Generated Lorem Ipsum paragraph?", "Please help", "I tried using several generators but none of them had enough generation parameters. Can you help me find one?", "where-lorem-ipsum",LocalDate.now(), null, createdStudent);
        Question createdQuestion = questionRepository.save(question);

        //add lecture votes
        LectureVote lectureVote = new LectureVote(createdTeacher1, createdlecture1, true);
        LectureVote createdLectureVote = lectureVoteRepository.save(lectureVote);

    }
}
