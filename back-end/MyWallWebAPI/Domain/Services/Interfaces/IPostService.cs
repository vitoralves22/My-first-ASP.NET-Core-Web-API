using MyWallWebAPI.Domain.Models;
using MyWallWebAPI.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Services.Interfaces
{
    public interface IPostService
    {
        Task<List<PostDTO>> ListPosts();
        Task<List<PostDTO>> ListPostsByCurrentUser();
        Task<Post> GetPost(int postId);
        Task<Post> CreatePost(Post post);
        Task<int> UpdatePost(Post post);
        Task<bool> DeletePostAsync(int postId);

    }
}
