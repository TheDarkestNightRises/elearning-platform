package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.Comment;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.Teacher;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.CommentRepository;
import via.dk.elearn.repository.LectureRepository;
import via.dk.elearn.service.mapper.CommentMapper;
import via.dk.elearn.service.mapper.LectureMapper;

import java.util.List;
import java.util.Optional;

@GRpcService
public class CommentServiceImpl extends CommentServiceGrpc.CommentServiceImplBase{

    private CommentRepository commentRepository;
    private LectureRepository lectureRepository;

    @Autowired
    public CommentServiceImpl(CommentRepository commentRepository, LectureRepository lectureRepository) {
        this.commentRepository = commentRepository;
        this.lectureRepository = lectureRepository;
    }


    @Override
    public void createNewComment(CommentModel request, StreamObserver<CommentModel> responseObserver) {
        Comment comment = CommentMapper.convertGrpcModelToComment(request);
        System.out.println(comment);
        Comment commentFromDb = commentRepository.save(comment);
        CommentModel commentModel = CommentMapper.convertCommentToGrpcModel(commentFromDb);
        responseObserver.onNext(commentModel);
        responseObserver.onCompleted();
    }

    @Override
    public void getCommentByLectureId(LectureId request, StreamObserver<CommentModel> responseObserver) {
        Optional<Lecture> lecture = lectureRepository.findById(request.getId());
        List<Comment> comments = commentRepository.findAllByLecture(lecture.get());
        if (comments.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The comments are not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Comments not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
        } else {

            for (Comment comment : comments) {
                CommentModel commentModel = CommentMapper.convertCommentToGrpcModel(comment);
                responseObserver.onNext(commentModel);
            }
            responseObserver.onCompleted();
        }
    }
}
