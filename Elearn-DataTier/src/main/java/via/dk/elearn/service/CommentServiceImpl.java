package via.dk.elearn.service;

import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.Comment;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.CommentRepository;
import via.dk.elearn.repository.LectureRepository;
import via.dk.elearn.service.mapper.CommentMapper;
import via.dk.elearn.service.mapper.LectureMapper;

@GRpcService
public class CommentServiceImpl extends CommentServiceGrpc.CommentServiceImplBase{

    private CommentRepository commentRepository;

    @Autowired
    public CommentServiceImpl(CommentRepository commentRepository) {
        this.commentRepository = commentRepository;
    }


    @Override
    public void createNewComment(CommentModel request, StreamObserver<CommentModel> responseObserver) {
        Comment comment = CommentMapper.convertGrpcModelToComment(request);
        Comment commentFromDb = commentRepository.save(comment);
        CommentModel commentModel = CommentMapper.convertCommentToGrpcModel(commentFromDb);
        responseObserver.onNext(commentModel);
        responseObserver.onCompleted();
    }
}
