package via.dk.elearn.service;

import com.google.protobuf.Any;
import com.google.rpc.ErrorInfo;
import io.grpc.protobuf.StatusProto;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import via.dk.elearn.models.Country;
import via.dk.elearn.models.University;
import via.dk.elearn.protobuf.*;
import via.dk.elearn.repository.CountryRepository;
import via.dk.elearn.service.mapper.CountryMapper;
import via.dk.elearn.service.mapper.UniversityMapper;

import java.util.List;
import java.util.Optional;
@GRpcService
public class CountryServiceImpl extends CountryServiceGrpc.CountryServiceImplBase {

    private CountryRepository countryRepository;

    public CountryServiceImpl(CountryRepository countryRepository) {
        this.countryRepository = countryRepository;
    }

    @Override
    public void getCountries(CountryRequest request, StreamObserver<CountryModel> responseObserver) {
        List<Country> countries = countryRepository.findAll();
        if (countries.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("No countries were not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("Countries not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
            return;
        }
        for (Country country : countries) {
            CountryModel countryModel = CountryMapper.convertCountryToGrpcModel(country);
            responseObserver.onNext(countryModel);
        }
        responseObserver.onCompleted();
    }

    @Override
    public void getCountryById(CountryId request, StreamObserver<CountryModel> responseObserver) {
        Optional<Country> country = countryRepository.findById(request.getId());
        if (country.isEmpty()) {
            com.google.rpc.Status status = com.google.rpc.Status.newBuilder()
                    .setCode(com.google.rpc.Code.NOT_FOUND.getNumber())
                    .setMessage("The requested user was not found")
                    .addDetails(Any.pack(ErrorInfo.newBuilder()
                            .setReason("User not found")
                            .build()))
                    .build();
            responseObserver.onError(StatusProto.toStatusRuntimeException(status));
        } else {
            Country countryFound = country.get();
            CountryModel countryModel = CountryMapper.convertCountryToGrpcModel(countryFound);
            responseObserver.onNext(countryModel);
            responseObserver.onCompleted();
        }
    }
}
