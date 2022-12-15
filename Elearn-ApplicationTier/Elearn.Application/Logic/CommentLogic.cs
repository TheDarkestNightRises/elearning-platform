using System.Security.AccessControl;
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

    public async Task<Comment> CreateAsync(Comment comment)
    { 
        Lecture? lecture = await _lectureService.GetByIdAsync(comment.Lecture.Id);
        User? user = await _userService.GetUserByIdAsync(comment.Author.Id);
        if (lecture == null)
        {
            throw new Exception($"Lecture was not found.");
        }
        if (user == null)
        {
            throw new Exception($"User was not found.");
        }
        ValidateComment(comment);
        Comment commentAppended = new Comment(user,lecture,comment.Text);
        Comment created = await _commentService.CreateAsync(commentAppended);
        return created;
    }
    

    public async Task<List<Comment>> GetAllCommentsByLectureId(long id) 
    {
        return await _commentService.GetAllCommentsByLectureId(id);
    }

    public async Task DeleteCommentAsync(long id)
    {
        Comment? comment = await _commentService.GetCommentById(id);
        if (comment == null)
        {
            throw new Exception($"Comment with id {id} was not found.");
        }
        await _commentService.DeleteCommentAsync(comment);
    }

    private void ValidateComment(Comment comment)
    {
        if (string.IsNullOrEmpty(comment.Text)) throw new Exception("Input cannot be empty.");
    }
}