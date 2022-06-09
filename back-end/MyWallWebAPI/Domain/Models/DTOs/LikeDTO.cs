using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Models
{
    public class LikeDTO
    {
        public int LikeId { get; set; }
        public string LikeOwner { get; set; }
        public DateTime Data { get; set; }
        public string PostTitle { get; set; }
        public string LikeReceiver { get; set; }


        public static List<LikeDTO> toListDTO (List<Like> likes)
        {
            List<LikeDTO> likesDTO = new();

            foreach (Like like in likes)
            {
               
                likesDTO.Add(new LikeDTO()
                {
                    LikeId = like.Id,
                    PostTitle = like.Post.Titulo,
                    Data = like.Data,
                    LikeOwner = like.ApplicationUser.UserName,
                    LikeReceiver = like.Post.ApplicationUser.UserName
                });

            }

            return likesDTO;
        }
    }
}
