package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.Code;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.Question;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.QuestionRepository;
import via.dk.elearn.service.mapper.QuestionMapper;

import java.util.List;

@GRpcService
public class QuestionServiceImpl extends QuestionServiceGrpc.QuestionServiceImplBase {
    private QuestionRepository questionRepository;

    @Autowired
    public QuestionServiceImpl(QuestionRepository questionRepository) {
        this.questionRepository = questionRepository;
    }

    @Override
    public void getQuestion(QuestionUrl request, StreamObserver<QuestionModel> responseObserver) {
        List<Question> questions = questionRepository.findByUrl(request.getUrl());
        if (questions.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The question is not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("question not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }
        Question question = questions.get(0);
        QuestionModel questionModel = QuestionMapper.convertLectureToGrpcModel(question);
        responseObserver.onNext(questionModel);
        responseObserver.onCompleted();
    }

    @Override
    public void getAllQuestion(NewQuestionRequest request, StreamObserver<QuestionModel> responseObserver) {
        List<Question> questions = questionRepository.findAll();
        if (questions.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The questions are not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Questions not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            responseObserver.onCompleted();
        } else {
            for (Question question : questions) {
                QuestionModel questionModel = QuestionMapper.convertLectureToGrpcModel(question);
                responseObserver.onNext(questionModel);
            }
            responseObserver.onCompleted();
        }
    }

    @Override
    public void createNewQuestion(QuestionModel request, StreamObserver<QuestionModel> responseObserver) {
        Question question = QuestionMapper.convertGrpcModelToLecture(request);
        Question questionFromDB = questionRepository.save(question);
        QuestionModel questionGrpcModel = QuestionMapper.convertLectureToGrpcModel(questionFromDB);
        responseObserver.onNext(questionGrpcModel);
        responseObserver.onCompleted();
    }
}
