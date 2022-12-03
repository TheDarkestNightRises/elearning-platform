using System.Globalization;

namespace Shared.Extensions;

public static class PaginationExtension
{
    public static void AddPaginationHeader<T>(this HttpContext httpContext,
        IEnumerable<T> enumerable, int recordsPerPage)
    {
        double quantity = enumerable.Count();
        double pagesSize = Math.Ceiling(quantity / recordsPerPage);
        httpContext.Response.Headers.Add("pagesQuantity", pagesSize.ToString(CultureInfo.CurrentCulture));
    }
}