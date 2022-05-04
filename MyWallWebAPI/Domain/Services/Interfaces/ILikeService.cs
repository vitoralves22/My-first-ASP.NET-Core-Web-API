using MyWallWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Services.Interfaces
{
    public interface ILikeService
    {
        Task<List<Like>> ListLikes();
        Task<List<Like>> ListLikesByCurrentUser();
        Task<List<Like>> ListLikesByPost(int postId);
        Task<Like> GetLike(int likeId);
        Task<Like> DoLike(int postId);
        Task<bool> UndoLike(int postId);
        Task<int> GetCountOfLikesInAPost(int postId);
       
    }
}
