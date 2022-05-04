using MyWallWebAPI.Domain.Models;
using MyWallWebAPI.Domain.Services.Interfaces;
using MyWallWebAPI.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Services.Implementations
{
    public class LikeService : ILikeService
    {
        private readonly LikeRepository _likeRepository;
        private readonly IAuthService _authService;
        private readonly IPostService _postService;

        public LikeService(LikeRepository likeRepository, IAuthService authService, IPostService postService)
        {
            _authService = authService;
            _postService = postService;
            _likeRepository = likeRepository;
        }

        public async Task<List<Like>> ListLikes()
        {
            List<Like> list = await _likeRepository.ListLikes();

            return list;
        }

        public async Task<List<Like>> ListLikesByCurrentUser()
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            List<Like> list = await _likeRepository.ListLikesByApplicationUserId(currentUser.Id);

            return list;
        }

        public async Task<List<Like>> ListLikesByPost(int postId)
        {
            List<Like> likesByPostId = await _likeRepository.ListLikesByPostId(postId);
            return likesByPostId;
        }

        public async Task<Like> GetLike(int likeId)
        {
            Like like = await _likeRepository.GetLikeById(likeId);

            if (like == null)
                throw new ArgumentException("Like não existe!");

            return like;
        }

        public async Task<Like> DoLike(int postId)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();
            Post postFinded = await _postService.GetPost(postId);
            Like likeFinded = await _likeRepository.FindLikeByPostAndUserId(postId, currentUser.Id);
            //List<Like> myLikes = await _likeRepository.ListLikesByApplicationUserId(currentUser.Id);

            if (postFinded == null)
                throw new ArgumentException("Post não existe!");

            if (postFinded.ApplicationUserId == currentUser.Id)
                throw new ArgumentException("Você não pode dar like no seu próprio Post!");

            if (likeFinded != null)
                throw new ArgumentException("Você não pode dar mais de um like em um mesmo post!");

            /*foreach (Like like in myLikes) 
            { 
                if(like.PostId == postId)
                {
                    throw new ArgumentException("Você não pode dar mais de um like em um mesmo post!");
                }
            }*/

            Like novoLike = new()
            {
                ApplicationUserId = currentUser.Id,
                Data = DateTime.Now,
                PostId = postId,
                Post = postFinded
            };

            novoLike = await _likeRepository.CreateLike(novoLike);

            return novoLike;
        }

        public async Task<bool> UndoLike(int postId)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            Like findLike = await _likeRepository.FindLikeByPostAndUserId(postId, currentUser.Id);

            if (findLike == null)
                throw new ArgumentException("Like não existe!");

            
            await _likeRepository.DeleteLikeAsync(findLike.Id);

            return true;
        }

        public async Task<int> GetCountOfLikesInAPost(int postId)
        {
            List<Like> likesByPostId = await _likeRepository.ListLikesByPostId(postId);
            
            return likesByPostId.Count;
        }

    }
}
