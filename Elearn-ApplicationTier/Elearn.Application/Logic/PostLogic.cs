using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;


namespace Elearn.Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostService _postService;
    private readonly IUserService _userService;

    public PostLogic(IPostService postService, IUserService userService)
    {
        _postService = postService;
        _userService = userService;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        //TODO: validate user when login part done
        //TODO: validate unique url
        //ValidateCreationDto(dto);
        User user = await _userService.GetUserByNameAsync(dto.Username);
        if (user is null)
        {
            throw new Exception("User not found in database");
        }
        Post post = new Post(dto.Title, dto.Body, dto.Url, dto.Image,user);
        Post created = await _postService.CreateNewPostAsync(post);
        //PostDto createdDto = new PostDto(created.PostId, created.Title, created.Body, created.Url, created.Image, created.Author, created.DateCreated);
        
        return created;
    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await _postService.GetAllPostsAsync();
    }

    public async Task<Post?> GetPostAsync(string url)
    {
        return await _postService.GetPostAsync(url);
    }

    private void ValidateCreationDto(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Body)) throw new Exception("Post body cannot be empty.");
        if (string.IsNullOrEmpty(dto.Url)) throw new Exception("Url cannot be empty.");
    }
}