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
    }
}
