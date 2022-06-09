namespace MyWallWebAPI.Domain.Models
{
    public class MessageReceiver
    {
        public string ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }

        public int MessageId { get; set; }
        public Message Message { get; set; }

        public bool IsRead { get; set; }
        public bool IsDeletedByReceiver { get; set; }
    }
}
