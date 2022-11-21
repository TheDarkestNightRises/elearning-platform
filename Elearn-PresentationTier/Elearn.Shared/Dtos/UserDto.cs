namespace Elearn.Shared.Dtos;

public class UserDto
{
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    
    public string Name { get; set; }
    
    public string Role { get; set; }
    
    public int SecurityLevel { get; set; }
}