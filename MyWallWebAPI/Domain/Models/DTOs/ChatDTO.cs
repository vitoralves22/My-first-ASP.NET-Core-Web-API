using System.Collections.Generic;

namespace MyWallWebAPI.Domain.Models.DTOs
{
    public class ChatDTO
    {
        public string ChatMembers { get; set; }
        public List<MessageDTO> MessagesDTO { get; set; }

    }
}
