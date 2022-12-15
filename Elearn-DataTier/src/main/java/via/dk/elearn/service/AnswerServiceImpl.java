package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import via.dk.elearn.models.Answer;
import via.dk.elearn.models.Comment;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.Question;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.AnswerRepository;
import via.dk.elearn.repository.CommentRepository;
import via.dk.elearn.repository.LectureRepository;
import via.dk.elearn.repository.QuestionRepository;
import via.dk.elearn.service.mapper.AnswerMapper;
import via.dk.elearn.service.mapper.CommentMapper;

import java.util.List;
import java.util.Optional;

@GRpcService
public class AnswerServiceImpl extends AnswerServiceGrpc.AnswerServiceImplBase {

    private AnswerRepository answerRepository;
    private QuestionRepository questionRepository;

    public AnswerServiceImpl(AnswerRepository answerRepository, QuestionRepository questionRepository) {
        this.answerRepository = answerRepository;
        this.questionRepository = questionRepository;
    }



    @Override
    public void createNewAnswer(AnswerModel request, StreamObserver<AnswerModel> responseObserver) {
        Answer answer = AnswerMapper.convertGrpcModelToAnswer(request);
        System.out.println(answer);
        Answer answerFromDb = answerRepository.save(answer);
        AnswerModel answerModel = AnswerMapper.convertAnswerToGrpcModel(answerFromDb);
        responseObserver.onNext(answerModel);
        responseObserver.onCompleted();
    }

    @Override
    public void getAnswerByQuestionId(QuestionId request, StreamObserver<AnswerModel> responseObserver) {
        Optional<Question> question = questionRepository.findById(request.getId());
        List<Answer> answers = answerRepository.findAllByQuestion(question.get());

        for (Answer answer : answers) {
            AnswerModel answerModel = AnswerMapper.convertAnswerToGrpcModel(answer);
            responseObserver.onNext(answerModel);
        }
        responseObserver.onCompleted();
    }



    @Override
    public void getAnswerById(AnswerId request, StreamObserver<AnswerModel> responseObserver) {
        Optional<Answer> answer = answerRepository.findById(request.getId());
        if (answer.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The requested answer was not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Answer not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
        } else {
            Answer answerFound = answer.get();
            AnswerModel answerModel = AnswerMapper.convertAnswerToGrpcModel(answerFound);
            responseObserver.onNext(answerModel);
            responseObserver.onCompleted();
        }
    }

    @Override
    public void deleteAnswer(AnswerModel request, StreamObserver<Nothing> responseObserver) {
        Optional<Answer> findAnswer = answerRepository.findById(request.getId());
        Answer answerFound = findAnswer.get();
        answerRepository.delete(answerFound);
        responseObserver.onNext(null);
        responseObserver.onCompleted();
    }
}
