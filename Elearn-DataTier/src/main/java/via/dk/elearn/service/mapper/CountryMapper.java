package via.dk.elearn.service.mapper;

import org.springframework.stereotype.Component;
import via.dk.elearn.models.Country;
import via.dk.elearn.models.University;
import via.dk.elearn.protobuf.CountryModel;
import via.dk.elearn.protobuf.UniversityModel;

@Component
public class CountryMapper {
    public static CountryModel convertCountryToGrpcModel(Country country) {
        return CountryModel.newBuilder()
                .setId(country.getId())
                .setName(country.getCountryName())
                .build();
    }
    public static Country convertGrpcModelToCountry(CountryModel model) {
        return Country.builder()
                .id(model.getId())
                .countryName(model.getName())
                .build();
    }
}
