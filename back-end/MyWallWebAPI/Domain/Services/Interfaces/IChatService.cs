using MyWallWebAPI.Domain.Models;
using MyWallWebAPI.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Services.Interfaces
{
    public interface IChatService
    {   
        Task<String> IniciateChat(List<string> usersId);
        Task<ChatDTO> GetChat(int chatId);
        Task<List<ChatDTO>> ListChat();
        Task<ChatUser> AddUserToChat(String UserId, int chatId);
        Task<bool> RemoveUserFromChat(String UserId, int chatId);

        Task<List<MessageDTO>> ListMessagesInChat(int ChatId);
        Task<String> SendMessage(MessageDTO messageDTO);
        Task<bool> DeleteMessage(int messageId);
        Task<int> UpdateMessage(Message message);
       
        Task<ChatInvitation> InviteUserToChat(String email, int chatId);
        Task<List<ChatInvitationDTO>> ListReceivedChatInvitationsByCurrentUserId();
        Task<int> AcceptInvitation(int id);
        Task<int> DenyInvitation(int id);
    }
}
