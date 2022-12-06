
using Elearn.Shared.Models;

namespace Elearn.Shared.Dtos;

public class LectureCreationDto
{
    public string Title{ get; set; }
    public string Body{ get; set; }
    public string Url{ get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Username{ get; set; }

    public DateTime Date { get; set; } = DateTime.Now;
    

    public LectureCreationDto()
    {
    }


    public override string ToString()
    {
        return $"{Title} {Body} {Url}";
    }
}