package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import via.dk.elearn.models.Lecture;
import via.dk.elearn.models.Moderator;
import via.dk.elearn.models.Teacher;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.LectureRepository;
import via.dk.elearn.repository.ModeratorRepository;
import via.dk.elearn.repository.TeacherRepository;
import via.dk.elearn.service.mapper.LectureMapper;
import via.dk.elearn.service.mapper.ModeratorMapper;
import via.dk.elearn.service.mapper.TeacherMapper;

import java.util.List;
import java.util.Optional;

public class ModeratorServiceImpl  extends ModeratorServiceGrpc.ModeratorServiceImplBase{
    private ModeratorRepository moderatorRepository;

    @Autowired
    public ModeratorServiceImpl(ModeratorRepository moderatorRepository) {
        this.moderatorRepository = moderatorRepository;
    }

    @Override
    public void getModeratorByUsername(ModeratorUsername request, StreamObserver<ModeratorModel> responseObserver) {
        List<Moderator> moderators = moderatorRepository.findByUsername(request.getUsername());
        if (moderators.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The Moderator is not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("User not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }
        Moderator moderator = moderators.get(0);
        ModeratorModel moderatorModel = ModeratorMapper.convertModeratorToGrpcModel(moderator);
        responseObserver.onNext(moderatorModel);
        responseObserver.onCompleted();
    }
}
