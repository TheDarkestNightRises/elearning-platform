using Elearn.Application.LogicInterfaces;
using Elearn.Application.RepositoryContracts;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;


namespace Elearn.Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public PostLogic(IPostRepository postRepository, IUserRepository userRepository)
    {
        this._postRepository = postRepository;
        this._userRepository = userRepository;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        //TODO: validate user when login part done
        //TODO: validate unique url
        //ValidateCreationDto(dto);
        User user = await _userRepository.GetUserByNameAsync(dto.Username);
        Post post = new Post(dto.Title, dto.Body, dto.Url, dto.Image, user);
        Post created = await _postRepository.CreateNewPostAsync(post);
        //PostDto createdDto = new PostDto(created.PostId, created.Title, created.Body, created.Url, created.Image, created.Author, created.DateCreated);
        
        return created;
    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await _postRepository.GetAllPostsAsync();
    }

    public async Task<Post?> GetPostAsync(string url)
    {
        return await _postRepository.GetPostAsync(url);
    }

    private void ValidateCreationDto(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Body)) throw new Exception("Post body cannot be empty.");
        if (string.IsNullOrEmpty(dto.Url)) throw new Exception("Url cannot be empty.");
    }
}