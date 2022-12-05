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
        Name = username;
        Password = password;
        Email = email;
        Image = image;
        Approved = approved;
    }

    public UpdateUserDto()
    {
    }
    
    
    public override string ToString()
    {
        return $"{Email} {Name} {Image} {Approved}";
    }
}