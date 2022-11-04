using Shared.Models;

namespace Shared.Extensions;

public static class Extensions
{
    public static PostDto AsDto(this Post post) 
    {
        return new PostDto
        {
            Id = post.PostId,
            Url = post.Url,
            Image = post.Image,
            Title = post.Title,
            Body = post.Body,
            DateCreated = post.DateCreated
        };
    }

    public static IEnumerable<PostDto> AsDto(this IEnumerable<Post> posts)
    {
        var products = (from post in posts 
            select new PostDto 
            {
                Id = post.PostId,
                Url = post.Url,
                Image = post.Image,
                Title = post.Title,
                Body = post.Body,
                DateCreated = post.DateCreated
                
            });
        return products;                
    }
    public static Post AsBase(this PostDto postDto) 
    {
        return new Post
        {
            PostId = postDto.Id,
            Url = postDto.Url,
            Image = postDto.Image,
            Title = postDto.Title,
            Body = postDto.Body,
            DateCreated = postDto.DateCreated
        };
    }
    public static Post AsBaseFromCreation(this PostCreationDto postDto) 
    {
        return new Post
        {
            Url = postDto.Url,
            Image = postDto.Image,
            Title = postDto.Title,
            Body = postDto.Body,
        };
    }
}