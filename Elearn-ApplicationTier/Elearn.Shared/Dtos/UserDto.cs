namespace Elearn.Shared.Dtos;

public class UserDto
{

    public long Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; } 
    public string Role { get; set; }
    public string Image { get; set; }
    public int SecurityLevel { get; set; }
    public long? UniversityId { get; set; }
    public long? CountryId { get; set; }
    
    public bool Approved { get; set; }


    public UserDto(long id, string username, string password, string email, string name, string role, string image, int securityLevel, long universityId, long countryId)
    {
        Id = id;
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Role = role;
        Image = image;
        SecurityLevel = securityLevel;
        UniversityId = universityId;
        CountryId = countryId;
    }

    public UserDto(string username, string password, string email, string name, string role, string image, int securityLevel, long universityId, long countryId)
    {
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Role = role;
        Image = image;
        SecurityLevel = securityLevel;
        UniversityId = universityId;
        CountryId = countryId;
    }

    public UserDto()
    {
    }
    
    public override string ToString()
    {

        return $"{Id} {Name} ";
    }
}