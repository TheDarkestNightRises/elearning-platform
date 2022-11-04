﻿using Shared.Models;

namespace Elearn.Application.RepositoryInterfaces;

public interface IPostRepository
{
    Task<List<Post>> GetAllPostsAsync();
    Task<Post?> GetPostAsync(string url);
    Task<Post> CreateNewPostAsync(Post post);
}