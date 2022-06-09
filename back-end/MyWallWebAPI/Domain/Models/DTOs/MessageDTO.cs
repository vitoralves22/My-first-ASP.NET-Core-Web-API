using System;

namespace MyWallWebAPI.Domain.Models.DTOs
{
    public class MessageDTO
    {
        public int  ChatId { get; set; }
        public int MessageId { get; set; }
        public string Content { get; set; }
        public string SenderName { get; set; }
        public string SenderId { get; set; }
        public DateTime Data { get; set; }
        public string Footer { get; set; }

    }
}
