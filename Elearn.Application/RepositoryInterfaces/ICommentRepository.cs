using Shared.Models;

namespace Elearn.Application.RepositoryInterfaces;

public interface ICommentRepository
{
    Task<Comment> CreateAsync(Comment comment);
}