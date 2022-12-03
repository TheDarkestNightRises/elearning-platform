using System.ComponentModel.DataAnnotations;

namespace Elearn.Shared.Dtos;

public class PaginationDto
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}