using System;
using System.Collections.Generic;

namespace MyWallWebAPI.Domain.Models.DTOs
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Owner { get; set; }
        public DateTime Data { get; set; }
        public int LikesCount { get; set; }


        public static List<PostDTO> toListDTO(List<Post> posts)
        {
            List<PostDTO> postsDTO = new();

            foreach (Post post in posts)
            {
                postsDTO.Add(new PostDTO()
                {
                    PostId = post.Id,
                    Titulo = post.Titulo,
                    Conteudo = post.Conteudo,
                    Data = post.Data,
                    Owner = post.ApplicationUser.UserName,
                    LikesCount = post.Likes.Count
                });

            }

            return postsDTO;
        }

    }
}
