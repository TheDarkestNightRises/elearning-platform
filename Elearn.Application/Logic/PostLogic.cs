using Elearn.Application.DaoInterfaces;
using Elearn.Application.LogicInterfaces;
using Shared;
using Shared.Models;

namespace Elearn.Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;

    public PostLogic(IPostDao postDao)
    {
        this.postDao = postDao;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        //TODO: validate user when login part done
        //ValidateCreationDto(dto);
        //Post post = new Post(dto.Title, dto.Body, dto.Url, dto.Image, dto.Author);
        Post created = await postDao.CreateAsync(post);
        //PostDto createdDto = new PostDto(created.PostId, created.Title, created.Body, created.Url, created.Image, created.Author, created.DateCreated);
        
        return created;
    }

    private void ValidateCreationDto(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Body)) throw new Exception("Post body cannot be empty.");
        if (string.IsNullOrEmpty(dto.Url)) throw new Exception("Url cannot be empty.");
    }
}