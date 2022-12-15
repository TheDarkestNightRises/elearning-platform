namespace Elearn.Shared.Dtos;

public class UserForCommentDto
{
    public string Username { get; set; }
    
    public string Name { get; set; }
    
    public string Image { get; set; }

    public UserForCommentDto(string username, string name, string image)
    {
        Username = username;
        Name = name;
        Image = image;
    }


    public UserForCommentDto()
    {
    }
}