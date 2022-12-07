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
    public UserCreationDto(string username, string password, string email, string name, string role)
    {
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Role = role;
    }
    
    public UserCreationDto(string username, string password, string email, string name, string role, int securityLevel, long universityId)
    {
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Role = role;
        SecurityLevel = securityLevel;
        UniversityId = universityId;
    }
    public UserCreationDto()
    {
    }
    
    public override string ToString()
    {
        return  $"{Name}";
    }
}