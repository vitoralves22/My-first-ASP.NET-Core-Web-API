using System;

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
    }
}
