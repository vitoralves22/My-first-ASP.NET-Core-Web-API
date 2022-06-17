using System;
using System.Collections.Generic;

namespace MyWallWebAPI.Domain.Models.DTOs
{
    public class ChatDTO
    {
        public int ChatId { get; set; }
        public string InitiatorName { get; set; }
        public List<string> ChatMembers { get; set; }
        public DateTime Data { get; set; }
        public List<MessageDTO> MessagesDTO { get; set; }


        public static List<ChatDTO> toListDTO(List<Chat> chats)
        {
            List<ChatDTO> chatsDTO = new();
           /* List<string> names = new List<string>();*/


            foreach (Chat chat in chats)
            {
               /* foreach (ChatUser chatUser in chat.ChatUsers)
                {
                    names.Add(chatUser.ApplicationUser.UserName);
                }*/

                chatsDTO.Add(new ChatDTO()
                {
                    InitiatorName = chat.Initiator.UserName,
                    Data = chat.Data,
                    ChatId = chat.Id
                    /*ChatMembers = names*/
                   
                });
            }

            return chatsDTO;
        }



    }
}
