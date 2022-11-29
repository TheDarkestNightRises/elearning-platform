namespace Elearn.Shared.Models;

public class User
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; } //THE NAME IS MISSING
    public string Role { get; set; }
    public string Image { get; set; }
    public int SecurityLevel { get; set; }
    public University? University { get; set; }

    public User(string username, string password, string email, string name, string role, string image, int securityLevel, University? university)
    {
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Role = role;
        Image = image;
        SecurityLevel = securityLevel;
        University = university;    
    }

    public User()
    {
    }
    
    public override string ToString()
    {
        return $"{Id} {Name} ";
    }

   
}