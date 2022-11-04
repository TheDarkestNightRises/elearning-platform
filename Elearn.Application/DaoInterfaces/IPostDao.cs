using Shared.Models;

namespace Elearn.Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);

}