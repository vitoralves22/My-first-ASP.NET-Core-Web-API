using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Models
{
    public class Chat
    {
        public int Id { get; set; }

        public string InitiatorId { get; set; }

        public ApplicationUser Initiator { get; set; }

        [JsonIgnore]
        public List<ChatUser> ChatUsers { get; set; }

        [JsonIgnore]
        public List<Message> Messages { get; set; }

        public DateTime Data { get; set; }
    }
}
