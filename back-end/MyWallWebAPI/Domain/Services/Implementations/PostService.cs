using MyWallWebAPI.Domain.Models;
using MyWallWebAPI.Domain.Models.DTOs;
using MyWallWebAPI.Domain.Services.Interfaces;
using MyWallWebAPI.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly PostRepository _postRepository;
        private readonly IAuthService _authService;
        private readonly LikeRepository _likeRepository;

        public PostService(PostRepository postRepository, IAuthService authService, LikeRepository likeRepository)
        {
            _authService = authService;
            _postRepository = postRepository;
            _likeRepository = likeRepository;
        }

        public async Task<List<PostDTO>> ListPosts()
        {
            List<Post> list = await _postRepository.ListPosts();

            return PostDTO.toListDTO(list);
        }

        public async Task<List<PostDTO>> ListPostsByCurrentUser()
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            List<Post> list = await _postRepository.ListPostsByApplicationUserId(currentUser.Id);

            return PostDTO.toListDTO(list);
        }

        public async Task<Post> GetPost(int postId)
        {
            Post post = await _postRepository.GetPostById(postId);

            if (post == null)
                throw new ArgumentException("Post não existe!");

            return post;
        }

        public async Task<Post> CreatePost(Post post)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            if ((post.Titulo == null || post.Titulo == "") && (post.Conteudo == null || post.Conteudo == ""))
                throw new ArgumentException("Para realizar uma publicação, todos os campos devem ser preenchidos.");

            if (post.Titulo == null || post.Titulo == "")
                throw new ArgumentException("Escolha um titulo para sua publicação.");

            if (post.Conteudo == null || post.Conteudo == "")
                throw new ArgumentException("Digite o conteúdo da sua publicação");

            Post novoPost = new()
            {
                ApplicationUserId = currentUser.Id,
                Data = DateTime.Now,
                Titulo = post.Titulo,
                Conteudo = post.Conteudo
            };

            novoPost = await _postRepository.CreatePost(novoPost);

            return novoPost;
        }

        public async Task<int> UpdatePost(Post post)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            Post findPost = await _postRepository.GetPostById(post.Id);
            if (findPost == null)
                throw new ArgumentException("Post não existe!");

            if (!findPost.ApplicationUserId.Equals(currentUser.Id))
                throw new ArgumentException("Sem permissão.");

            findPost.Titulo = post.Titulo;
            findPost.Conteudo = post.Conteudo;

            return await _postRepository.UpdatePost(findPost);
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            Post findPost = await _postRepository.GetPostById(postId);
            if (findPost == null)
                throw new ArgumentException("Post não existe!");

            if (!findPost.ApplicationUserId.Equals(currentUser.Id))
                throw new ArgumentException("Sem permissão.");

            await _postRepository.DeletePostAsync(postId);

            return true;
        }

      

       
    }
}
