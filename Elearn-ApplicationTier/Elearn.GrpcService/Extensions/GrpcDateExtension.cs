using ElearnGrpc;

namespace Elearn.GrpcService.Extensions;

public static class GrpcDateExtension
{
    public static DateModel AsGrpcModel(this DateTime date)
    {
        return new DateModel
        {
            Year = date.Year,
            Month = date.Month,
            Day = date.Day
        };
    }

    public static DateTime AsBase(this DateModel dateModel)
    {
        return new DateTime(dateModel.Year, dateModel.Month, dateModel.Day);
    }
}