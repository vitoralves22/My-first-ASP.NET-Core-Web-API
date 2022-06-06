using Microsoft.AspNetCore.Identity;
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

        [JsonIgnore]
        public List<MessageReceiver> MessageReceivers { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }

        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        public string Header { get; set; }
        public string Content { get; set; }
        public bool IsDeletedBySender { get; set; }

        public DateTime Data { get; set; }
    }
}
