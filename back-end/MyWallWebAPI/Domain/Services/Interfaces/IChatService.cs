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
        Task<List<MessageDTO>> ListMessagesInChat(int ChatId);
        Task<List<ChatDTO>> ListChat();
        Task<String> IniciateChat(List<string> usersId);
        Task<String> SendMessage(MessageDTO messageDTO);
        Task<bool> DeleteMessage(int messageId);
        Task<int> UpdateMessage(Message message);
        Task<ChatDTO> GetChat(int chatId);
      /*  Task<String> RemoveUserFromChat(int chatId, ApplicationUser User);
        Task<String> InviteUserToChat(String email);
        Task<String> AcceptInvitation();*/
        Task<ChatUser> AddUserToChat(String UserId, int chatId);
    }
}
