package via.dk.elearn.service.mapper;

import org.springframework.stereotype.Component;
import via.dk.elearn.protobuf.DateModel;

import java.time.LocalDate;

@Component
public class DateMapper {
    public static DateModel convertDateToGrpcModel(LocalDate localDate)
    {
        return DateModel.newBuilder()
                .setDay(localDate.getDayOfMonth())
                .setMonth(localDate.getMonthValue())
                .setYear(localDate.getYear())
                .build();
    }
    public static LocalDate convertGrpcModeltoDate(DateModel dateModel)
    {
        return LocalDate.of(dateModel.getYear(), dateModel.getMonth(), dateModel.getDay());
    }
}
