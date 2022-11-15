using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;


namespace Elearn.Application.Logic;

public class CommentLogic : ICommentLogic
{
    private readonly IPostService postService;
    private readonly ICommentService commentService;

    public CommentLogic(IPostService postService, ICommentService commentService)
    {
        this.postService = postService;
        this.commentService = commentService;
    }

    public async Task<Comment> CreateAsync(CommentCreationDto dto)
    { 
        Post? post = await postService.GetByIdAsync(dto.PostId);
        // if (post == null)
        // {
        //     throw new Exception($"Post was not found.");
        // }
        //
        // User? user = await UserDao.GetByIdAsync(dto.post.authorId);
        // if (post == null)
        // {
        //     throw new Exception($"Current user was not found.");
        // }
        ValidateComment(dto);
        Comment comment = new Comment(1,post,dto.Text);
        Comment created = await commentService.CreateAsync(comment);
        return created;
    }
    

    public Task<IEnumerable<Comment>> GetAsync(SearchCommentParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Comment> GetAllCommentsByPostUrlAsync(string url)
    {
        return commentService.GetAllCommentsByPostUrlAsync(url);
    }

    private void ValidateComment(CommentCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Text)) throw new Exception("Input cannot be empty.");
    }
}