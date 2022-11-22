package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.LectureVote;
import via.dk.elearn.models.LectureVoteId;
import via.dk.elearn.models.User;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.LectureRepository;
import via.dk.elearn.repository.LectureVoteRepository;
import via.dk.elearn.repository.UserRepository;
import via.dk.elearn.service.mapper.LectureMapper;
import via.dk.elearn.service.mapper.LectureVoteMapper;
import via.dk.elearn.service.mapper.UserMapper;

import java.util.Optional;

@GRpcService
public class LectureVoteServiceImpl extends LectureVoteServiceGrpc.LectureVoteServiceImplBase
{
    private LectureVoteRepository lectureVoteRepository;
    private UserRepository userRepository;

    private LectureRepository lectureRepository;
    @Autowired
    public LectureVoteServiceImpl(LectureVoteRepository lectureVoteRepository, UserRepository userRepository, LectureRepository lectureRepository) {
        this.lectureVoteRepository = lectureVoteRepository;
        this.userRepository = userRepository;
        this.lectureRepository = lectureRepository;
    }


    @Override
    public void voteLecture(VoteModel request, StreamObserver<VoteModel> responseObserver) {
        try {
            User user = UserMapper.convertGrpcModelToUser(request.getUser());
            Lecture lecture = LectureMapper.convertGrpcModelToLecture(request.getPost());
            boolean upvote = request.getUpvote();

            LectureVote lectureVote = new LectureVote(user, lecture, upvote);

            LectureVote lectureVoteFromDB = lectureVoteRepository.save(lectureVote);

            lectureVote.setUser(user);
            lectureVote.setLecture(lecture);

            responseObserver.onNext(LectureVoteMapper.convertLectureVoteToGrpcModel(lectureVote));

            responseObserver.onCompleted();
        }catch (Exception e)
        {
            e.printStackTrace();
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("Could not add lecture vote")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Vote not added")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            //responseObserver.onCompleted();
        }
    }

    @Override
    public void getLectureVotesCount(PostModel request, StreamObserver<VoteCounter> responseObserver) {
        try
        {
            Lecture lecture = LectureMapper.convertGrpcModelToLecture(request);
            long noOfUpvotes = lectureVoteRepository.countLectureVotesByUpvoteEqualsAndLectureEquals(true, lecture);
            long noOfDownvotes = lectureVoteRepository.countLectureVotesByUpvoteEqualsAndLectureEquals(false, lecture);
            VoteCounter counter = VoteCounter.newBuilder()
                    .setPost(request)
                    .setUpvoteCount(noOfUpvotes)
                    .setDownvoteCount(noOfDownvotes).build();
            responseObserver.onNext(counter);
            responseObserver.onCompleted();
        }catch ( Exception ex)
        {
            ex.printStackTrace();
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("Could not add get votes")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Vote not added")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
        }
    }

    @Override
    public void getVoteById(VoteId request, StreamObserver<VoteModel> responseObserver) {
        try {
            User user = UserMapper.convertGrpcModelToUser(request.getUser());
            Lecture lecture = LectureMapper.convertGrpcModelToLecture(request.getPost());

            LectureVoteId voteId = new LectureVoteId(user.getId(), lecture.getId());
            Optional<LectureVote> lectureVoteFromDB = lectureVoteRepository.findById(voteId);
            if(lectureVoteFromDB.isEmpty())
            {
                responseObserver.onNext(VoteModel.newBuilder().build());
            }
            else {
                LectureVote lectureVote = lectureVoteFromDB.get();
                lectureVote.setUser(user);
                lectureVote.setLecture(lecture);
                responseObserver.onNext(LectureVoteMapper.convertLectureVoteToGrpcModel(lectureVoteFromDB.get()));
            }
            responseObserver.onCompleted();
        }catch (Exception e)
        {
            e.printStackTrace();
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("Could not add lecture vote")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Vote not added")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            //responseObserver.onCompleted();
        }
    }
}
