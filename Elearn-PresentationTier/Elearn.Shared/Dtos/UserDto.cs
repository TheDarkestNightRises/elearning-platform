namespace Elearn.Shared.Models;

public class UserDto
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }

    public string Role { get; set; }

    public bool Approved { get; set; }
    public int SecurityLevel { get; set; }
    public long UniversityId { get; set; }
    public long CountryId { get; set; }

    public UserDto()
    {
    }

    public override string ToString()
    {
        return $"{Id} {Name}";
    }
}