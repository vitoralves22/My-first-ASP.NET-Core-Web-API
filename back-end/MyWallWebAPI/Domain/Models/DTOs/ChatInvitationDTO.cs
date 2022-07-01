using System;
using System.Collections.Generic;

namespace MyWallWebAPI.Domain.Models.DTOs
{
    public class ChatInvitationDTO
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public DateTime Data { get; set; }


        public static List<ChatInvitationDTO> toListDTO(List<ChatInvitation> invitations)
        {
            List<ChatInvitationDTO> invitationsDTO = new(); 

            foreach (ChatInvitation invitation in invitations)
            {
                invitationsDTO.Add(new ChatInvitationDTO()
                {
                    Id = invitation.Id,
                    ChatId = invitation.ChatId,
                    SenderName = invitation.Sender.UserName,
                    ReceiverName = invitation.Receiver.UserName,
                    Data = invitation.Data
                });
            }

            return invitationsDTO;
        }



    }
}
