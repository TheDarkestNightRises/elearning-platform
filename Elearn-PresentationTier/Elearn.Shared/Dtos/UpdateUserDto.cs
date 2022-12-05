namespace Elearn.Shared.Dtos;

public class UpdateUserDto
{
    public string Name { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    public string Image { get; set; }
    public bool Approved { get; set; }
    public UpdateUserDto(string username, string password, string email, string image, bool approved)
    {
        Image = image;
        Name = username;
        Password = password;
        Email = email;
        Approved = approved;
    }

    public UpdateUserDto()
    {
    }
    
    
    public override string ToString()
    {
        return $"{Email} {Name} {Password} {Image} {Approved}";
    }
 
}