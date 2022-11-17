using Elearn.Application.ServiceContracts;
using Elearn.Shared.Models;

namespace Elearn.GrpcService.Client;

public class CommentGrpcClient : ICommentService
{
    public Task<Comment> CreateAsync(Comment comment)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Comment> GetAllCommentsByPostUrlAsync(string url)
    {
        throw new NotImplementedException();
    }
}