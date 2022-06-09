using MyWallWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Services.Interfaces
{
    public interface ILikeService
    {
        Task<List<LikeDTO>> ListLikes();
        Task<List<LikeDTO>> ListLikesByCurrentUser();
        Task<List<LikeDTO>> ListLikesByPost(int postId);
        Task<Like> GetLike(int likeId);
        Task<Like> DoLike(int postId);
        Task<bool> UndoLike(int postId);
        Task<List<LikeDTO>> GenerateLikesDTOList(List<Like> likes);
    }
}