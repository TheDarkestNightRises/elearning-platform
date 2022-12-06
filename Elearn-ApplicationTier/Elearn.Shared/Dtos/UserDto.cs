namespace Elearn.Shared.Dtos;

public class UserDto
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }

    public string Role { get; set; }

    public int SecurityLevel
    {
        get; set;
    }
    public bool Approved { get; set; }
    
    
    public UserDto(string username, string password, string email, string name, string role, int securityLevel, string image, bool approved)
    {
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Role = role;
        SecurityLevel = securityLevel;
        Approved = approved;
        Image = image;
    }
    public UserDto()
    {
    }
    
    public override string ToString()
    {
        return $"{UserId} {Name}";
    }
}