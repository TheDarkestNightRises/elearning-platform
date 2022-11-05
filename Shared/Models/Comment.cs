using System.ComponentModel.DataAnnotations;
using Shared.Models;

namespace Shared.Models;

public class Comment
{
    public int CommentId { get; set; }
    
    //Actual user needed
    public int AuthorId{ get; set; }
    
    public Post Post{ get; set; }
    
    
    [Required, StringLength(150, ErrorMessage = "150 Characters MAX")]
    public string Text { get; set; }
    
    public DateTime DateCreated { get; set; } = DateTime.Now;

    public Comment(int authorId, Post post, string text)
    {
        AuthorId = authorId;
        Post = post;
        Text = text;
    }

    public Comment()
    {
        
    }
    public override string ToString()
    {
        return $"{CommentId} {AuthorId} {Post} {Text} {DateCreated}";
    }
    
 

}