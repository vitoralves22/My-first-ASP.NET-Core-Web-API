using System;

namespace MyWallWebAPI.Domain.Models.DTOs
{
    public class MessageDTO
    {
        public int MessageId { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string ReceiverId { get; set; }
        public string SenderId { get; set; }
        public bool IsRead { get; set; }
        public DateTime Data { get; set; }

    }
}
