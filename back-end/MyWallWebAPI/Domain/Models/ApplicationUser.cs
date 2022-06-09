using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [JsonIgnore]
        public List<Post> Posts { get; set; }

        [JsonIgnore]
        public List<Like> Likes { get; set; }

        [JsonIgnore]
        public List<Chat> Chats { get; set; }


        [JsonIgnore]
        public List<ChatUser> ChatUsers { get; set; }

        [JsonIgnore]
        public List<Message> Messages { get; set; }

        [JsonIgnore]
        public List<MessageReceiver> MessageReceivers { get; set; }
    }
}
