using Elearn.Application.LogicInterfaces;
using Elearn.Application.RepositoryInterfaces;
using Elearn.Data.Repository;
using Shared;
using Shared.Models;

namespace Elearn.Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostRepository _postRepository;

    public PostLogic(IPostRepository postRepository)
    {
        this._postRepository = postRepository;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        //TODO: validate user when login part done
        //TODO: validate unique url
        //ValidateCreationDto(dto);
        //Post post = new Post(dto.Title, dto.Body, dto.Url, dto.Image, dto.Author);
        Post created = await _postRepository.CreateNewPostAsync(post);
        //PostDto createdDto = new PostDto(created.PostId, created.Title, created.Body, created.Url, created.Image, created.Author, created.DateCreated);
        
        return created;
    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await _postRepository.GetAllPostsAsync();
    }
    private void ValidateCreationDto(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Body)) throw new Exception("Post body cannot be empty.");
        if (string.IsNullOrEmpty(dto.Url)) throw new Exception("Url cannot be empty.");
    }
}