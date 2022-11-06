
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Shared.Extensions;

public static class PostExtensions
{
    public static PostDto AsDto(this Post post) 
    {
        return new PostDto
        {
            Id = post.Id,
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
                Id = post.Id,
                Url = post.Url,
                Image = post.Image,
                Title = post.Title,
                Body = post.Body,
                DateCreated = post.DateCreated,
                Author = post.Author
            });
        return products;                
    }
    public static Post AsBase(this PostDto postDto) 
    {
        return new Post
        {
            Id = postDto.Id,
            Url = postDto.Url,
            Image = postDto.Image,
            Title = postDto.Title,
            Body = postDto.Body,
            DateCreated = postDto.DateCreated,
            Author = postDto.Author
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
            Author = postDto.Author
        };
    }
}