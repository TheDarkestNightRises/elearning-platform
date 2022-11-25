package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.Question;
import via.dk.elearn.models.User;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.LectureRepository;
import via.dk.elearn.repository.QuestionRepository;
import via.dk.elearn.repository.UserRepository;
import via.dk.elearn.service.mapper.LectureMapper;
import via.dk.elearn.service.mapper.QuestionMapper;
import via.dk.elearn.service.mapper.UserMapper;

import java.util.List;

@GRpcService
public class SearchServiceImpl extends SearchServiceGrpc.SearchServiceImplBase {

    private LectureRepository lectureRepository;
    private UserRepository userRepository;
    private QuestionRepository questionRepository;

    @Autowired
    public SearchServiceImpl(LectureRepository lectureRepository, UserRepository userRepository, QuestionRepository questionRepository) {
        this.lectureRepository = lectureRepository;
        this.userRepository = userRepository;
        this.questionRepository = questionRepository;
    }

    @Override
    public void searchLectures(SearchLecturesRequest request, StreamObserver<LectureModel> responseObserver) {
        List<Lecture> lectures = lectureRepository.findByTitleContaining(request.getTitle());
        if (lectures.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The lectures are not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Lectures not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }
        for (Lecture lecture : lectures) {
            LectureModel lectureModel = LectureMapper.convertLectureToGrpcModel(lecture);
            responseObserver.onNext(lectureModel);
        }
        responseObserver.onCompleted();
    }

    @Override
    public void searchUsers(SearchUsersRequest request, StreamObserver<UserModel> responseObserver) {
        List<User> users = userRepository.findByUsernameContaining(request.getUserName());
        if (users.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The lectures are not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Lectures not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }
        for (User user : users) {
            UserModel userModel = UserMapper.convertUserToGrpcModel(user);
            responseObserver.onNext(userModel);
        }
        responseObserver.onCompleted();
    }

    @Override
    public void searchQuestions(SearchQuestionsRequest request, StreamObserver<QuestionModel> responseObserver) {
        List<Question> questions = questionRepository.findByTitleContaining(request.getTitle());
        if (questions.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The lectures are not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Lectures not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }
        for (Question question : questions) {
            QuestionModel questionModel = QuestionMapper.convertQuestionToGrpcModel(question);
            responseObserver.onNext(questionModel);
        }
        responseObserver.onCompleted();
    }
}
