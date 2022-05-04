﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Models
{
    public class Like
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
