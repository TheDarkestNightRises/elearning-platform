package via.dk.elearn.service.mapper;

import org.springframework.stereotype.Component;
import via.dk.elearn.protobuf.DateModel;

import java.time.LocalDate;
import java.time.LocalDateTime;

@Component
public class DateMapper {
    public static DateModel convertDateToGrpcModel(LocalDateTime localDate)
    {
        return DateModel.newBuilder()
                .setDay(localDate.getDayOfMonth())
                .setMonth(localDate.getMonthValue())
                .setYear(localDate.getYear())
                .setHour(localDate.getHour())
                .setMinute(localDate.getMinute())
                .setSecond(localDate.getSecond())
                .build();
    }
    public static LocalDateTime convertGrpcModeltoDate(DateModel dateModel)
    {
        return LocalDateTime.of(dateModel.getYear(), dateModel.getMonth(), dateModel.getDay(),dateModel.getHour(), dateModel.getMinute(), dateModel.getSecond());
    }
}
