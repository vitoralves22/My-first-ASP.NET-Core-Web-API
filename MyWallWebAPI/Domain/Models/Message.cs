using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public bool IsRead { get; set; }
        public bool IsAnswer { get; set; }
        public bool IsDeletedBySender { get; set; }
        public bool IsDeletedByReceiver { get; set; }
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public string ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }
        public string Content { get; set; }
        public DateTime Data { get; set; }
    }
}
