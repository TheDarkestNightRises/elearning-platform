using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;


namespace Elearn.Application.Logic;

public class CommentLogic : ICommentLogic
{
    private readonly ILectureService _lectureService;
    private readonly ICommentService _commentService;
    private readonly IUserService _userService;

    public CommentLogic(ILectureService lectureService, ICommentService commentService, IUserService userService)
    {
        _lectureService = lectureService;
        _commentService = commentService;
        _userService = userService;
    }

    public async Task<Comment> CreateAsync(CommentCreationDto dto)
    { 
        Lecture? lecture = await _lectureService.GetByIdAsync(dto.LectureId);
        User? user = await _userService.GetUserByIdAsync(dto.UserId);
        if (lecture == null)
        {
            throw new Exception($"Lecture was not found.");
        }
        if (user == null)
        {
            throw new Exception($"User was not found.");
        }
        ValidateComment(dto);
        Comment comment = new Comment(user,lecture,dto.Text);
        Comment created = await _commentService.CreateAsync(comment);
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
        return _commentService.GetAllCommentsByPostUrlAsync(url);
    }

    private void ValidateComment(CommentCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Text)) throw new Exception("Input cannot be empty.");
    }
}