using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Models.DTOs
{
    public class AnswerDTO
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
    }
}

