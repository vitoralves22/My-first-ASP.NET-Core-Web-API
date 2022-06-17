using System;

namespace MyWallWebAPI.Domain.Models
{
    public class ChatInvitation
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public string ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }
        public DateTime Data { get; set; }
        public bool IsAccepted { get; set; } = false;
        public bool IsDenied { get; set; } = false;
    }
}
