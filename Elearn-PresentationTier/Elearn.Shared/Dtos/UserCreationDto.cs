namespace Elearn.Shared.Dtos;

public class UserCreationDto
{
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    
    public string Name { get; set; }
    
    
    public string Image { get; set; }

    
    public string Role { get; set; }
    
    public int SecurityLevel { get; set; }
    
    public long UniversityId { get; set; }
    
    public long CountryId { get; set; }

    public UserCreationDto(string username, string password, string email, string name, string image, string role, int securityLevel, long universityId, long countryId)
    {
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Image = image;
        Role = role;
        SecurityLevel = securityLevel;
        UniversityId = universityId;
        CountryId = countryId;
    }

    public UserCreationDto()
    {
    }
    
    public override string ToString()
    {
        return  $"{Name}";
    }
}