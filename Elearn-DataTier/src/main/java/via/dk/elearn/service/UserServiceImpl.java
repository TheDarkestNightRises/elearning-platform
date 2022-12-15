package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.*;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.*;
import via.dk.elearn.service.mapper.CountryMapper;
import via.dk.elearn.service.mapper.LectureMapper;
import via.dk.elearn.service.mapper.UniversityMapper;
import via.dk.elearn.service.mapper.UserMapper;

import java.util.List;
import java.util.Optional;

@GRpcService
public class UserServiceImpl extends UserServiceGrpc.UserServiceImplBase {

    private UserRepository userRepository;
    private TeacherRepository teacherRepository;
    private StudentRepository studentRepository;
    private CountryRepository countryRepository;
    private UniversityRepository universityRepository;

    @Autowired
    public UserServiceImpl(UserRepository userRepository, TeacherRepository teacherRepository, StudentRepository studentRepository, CountryRepository countryRepository, UniversityRepository universityRepository) {
        this.userRepository = userRepository;
        this.teacherRepository = teacherRepository;
        this.studentRepository = studentRepository;
        this.countryRepository = countryRepository;
        this.universityRepository = universityRepository;
    }

    @Override
    public void getUserByName(via.dk.elearn.protobuf.Name request, StreamObserver<UserModel> responseObserver) {

        Optional<User> user = userRepository.findFirstByName(request.getName());
        if (user.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The user is not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("User not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }
        Country country = user.get().getCountry();
        University university = user.get().getUniversity();
        UserModel userModel = UserMapper.convertUserToGrpcModel(user.get());
        userModel = UserModel.newBuilder(userModel)
                .setCountry(CountryMapper.convertCountryToGrpcModel(country))
                .build();
        userModel = UserModel.newBuilder(userModel)
                .setUniversity(UniversityMapper.convertUniversityToGrpcModel(university))
                .build();
        responseObserver.onNext(userModel);
        responseObserver.onCompleted();
    }

    @Override
    public void getUserByUsername(via.dk.elearn.protobuf.UserName request, StreamObserver<UserModel> responseObserver) {

        Optional<User> user = userRepository.findFirstByUsername(request.getUsername());
        if (user.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The user is not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("User not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }
        Country country = user.get().getCountry();
        University university = user.get().getUniversity();
        UserModel userModel = UserMapper.convertUserToGrpcModel(user.get());
        userModel = UserModel.newBuilder(userModel)
                .setCountry(CountryMapper.convertCountryToGrpcModel(country))
                .build();
        userModel = UserModel.newBuilder(userModel)
                .setUniversity(UniversityMapper.convertUniversityToGrpcModel(university))
                .build();
        responseObserver.onNext(userModel);
        responseObserver.onCompleted();
    }


    @Override
    public void createNewUser(UserModel request, StreamObserver<UserModel> responseObserver) {
        User user = UserMapper.convertGrpcModelToUser(request);

        University university = UniversityMapper.convertGrpcModelToUniversity(request.getUniversity());
        Country country = CountryMapper.convertGrpcModelToCountry(request.getCountry());

        user.setUniversity(university);
        user.setCountry(country);

        UserModel userModel;
        if (user.getRole().equals("Teacher")) {
            Teacher teacher = new Teacher(user.getUsername(), user.getEmail(), user.getName(), user.getPassword(), user.getImage(), user.getRole(), user.isApproved(), user.getSecurity_level(), user.getCountry(), user.getUniversity());
            Teacher teacherFromDB = teacherRepository.save(teacher);
            Teacher teacherFromDB2 = teacherRepository.findById(teacherFromDB.getId()).get();
            userModel = UserMapper.convertUserToGrpcModel(teacherFromDB2);
            userModel = UserModel.newBuilder(userModel)
                    .setCountry(CountryMapper.convertCountryToGrpcModel(teacherFromDB2.getCountry()))
                    .build();
            userModel = UserModel.newBuilder(userModel)
                    .setUniversity(UniversityMapper.convertUniversityToGrpcModel(teacherFromDB2.getUniversity()))
                    .build();

        } else if (user.getRole().equals("Student"))
        {
            Student student = new Student(user.getUsername(), user.getEmail(), user.getName(), user.getPassword(), user.getImage(), user.getRole(), user.isApproved(), user.getSecurity_level(), country,user.getUniversity());
            Student studentFromDB = studentRepository.saveAndFlush(student);
            Student studentFromDB2 = studentRepository.findById(studentFromDB.getId()).get();
            userModel = UserMapper.convertUserToGrpcModel(studentFromDB2);
            userModel = UserModel.newBuilder(userModel)
                    .setCountry(CountryMapper.convertCountryToGrpcModel(studentFromDB2.getCountry()))
                    .build();
            userModel = UserModel.newBuilder(userModel)
                    .setUniversity(UniversityMapper.convertUniversityToGrpcModel(studentFromDB2.getUniversity()))
                    .build();
        } else {
            User userFromDb = userRepository.saveAndFlush(user);
            User userFromDb2 = userRepository.findById(userFromDb.getId()).get();
            userModel = UserMapper.convertUserToGrpcModel(userFromDb);
            userModel = UserModel.newBuilder(userModel)
                    .setCountry(CountryMapper.convertCountryToGrpcModel(userFromDb2.getCountry()))
                    .build();
            userModel = UserModel.newBuilder(userModel)
                    .setUniversity(UniversityMapper.convertUniversityToGrpcModel(userFromDb2.getUniversity()))
                    .build();
        }
        responseObserver.onNext(userModel);
        responseObserver.onCompleted();
    }

    @Override
    public void updateUser(UserModel request, StreamObserver<UserModel> responseObserver) {

        Optional<User> findUser = userRepository.findById(request.getId());
        User userFound = findUser.get();
        userFound.setPassword(request.getPassword());
        userFound.setEmail(request.getEmail());
        userFound.setImage(request.getImage());
        userFound.setApproved(request.getApproved());
        userRepository.save(userFound);
        UserModel userModel = UserMapper.convertUserToGrpcModel(userFound);
        responseObserver.onNext(userModel);
        responseObserver.onCompleted();
    }


    @Override
    public void deleteUser(UserModel request, StreamObserver<Nothing> responseObserver) {
        Optional<User> findUser = userRepository.findById(request.getId());
        User userFound = findUser.get();
        userRepository.delete(userFound);
        responseObserver.onNext(null);
        responseObserver.onCompleted();
    }

    @Override
    public void getUserByID(UserId request, StreamObserver<UserModel> responseObserver) {
        Optional<User> user = userRepository.findById(request.getId());
        if (user.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The requested user was not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("User not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
        } else {
            Country country = user.get().getCountry();
            University university = user.get().getUniversity();
            UserModel userModel = UserMapper.convertUserToGrpcModel(user.get());
            userModel = UserModel.newBuilder(userModel)
                    .setCountry(CountryMapper.convertCountryToGrpcModel(country))
                    .build();
            userModel = UserModel.newBuilder(userModel)
                    .setUniversity(UniversityMapper.convertUniversityToGrpcModel(university))
                    .build();
            responseObserver.onNext(userModel);
            responseObserver.onCompleted();
        }
    }

    @Override
    public void getAllUsers(UserId request, StreamObserver<UserModel> responseObserver) {
        List<User> users = userRepository.findAll();
        if (users.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("User is not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("User not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
        } else {

            for (User user : users) {
                Country country = user.getCountry();
                University university = user.getUniversity();
                UserModel userModel = UserMapper.convertUserToGrpcModel(user);
                userModel = UserModel.newBuilder(userModel)
                        .setCountry(CountryMapper.convertCountryToGrpcModel(country))
                        .build();
                userModel = UserModel.newBuilder(userModel)
                        .setUniversity(UniversityMapper.convertUniversityToGrpcModel(university))
                        .build();
                responseObserver.onNext(userModel);
            }
            responseObserver.onCompleted();
        }
    }
}
