using Shared.Models;

namespace Shared.Dtos;

public class CommentDto
{
    public int Id { get; set; }
    
    //Actual user needed
    public int AuthorId{ get; set; }
    
    public Post post{ get; set; }
    
    public String Text { get; set; }
    
    public DateTime DateCreated { get; set; } 

    public CommentDto(int AuthorId, Post post, string Text, DateTime dateCreated)
    {
        this.AuthorId = AuthorId;
        this.post = post;
        this.Text = Text;
        DateCreated = dateCreated;
    }
    
    public override string ToString()
    {
        return $"{Id} {AuthorId} {post} {Text} {DateCreated}";
    }

}