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
    public int SecurityLevel { get; set; }
    
    public string UniversityName { get; set; }
    
    public UserDto(string username, string password, string email, string name, string role, int securityLevel, string universityName)
    {
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Role = role;
        SecurityLevel = securityLevel;
        UniversityName = universityName;
    }
    
    public UserDto(long id, string username, string password, string email, string name, string role, int securityLevel)
    {
        Id = id;
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Role = role;
        SecurityLevel = securityLevel;
    }
    public UserDto()
    {
    }
    
    public override string ToString()
    {
        return $"{Id} {Name}";
    }
}