namespace Elearn.Shared.Dtos;

public class UpdateUserDto
{
    public string Name { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    public string Image { get; set; }

    public UpdateUserDto(string username, string password, string email, string image)
    {
        Name = username;
        Password = password;
        Email = email;
        Image = image;
    }

    public UpdateUserDto()
    {
    }
    
    
    public override string ToString()
    {
        return $"{Email} {Name} {Image}";
    }
}