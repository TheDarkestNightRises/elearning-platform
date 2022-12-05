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


    public UserDto(string username, string password, string email, string name, string role, string image, int securityLevel)
    {
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Role = role;
        Image = image;
        SecurityLevel = securityLevel;
        
    }

    public UserDto(long id, string username, string password, string email, string name, string role, string image, int securityLevel)
    {
        Id = id;
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Role = role;
        Image = image;
        SecurityLevel = securityLevel;
    }

    public UserDto()
    {
    }
    
    public override string ToString()
    {
        return $"{Id} {Name} ";
    }
}