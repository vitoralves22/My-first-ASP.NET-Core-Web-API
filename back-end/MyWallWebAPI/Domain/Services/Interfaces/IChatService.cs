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
        Task<ChatDTO> ListMessagesInChat(int ChatId);
        Task<String> IniciateChat(List<string> usersId);
        Task<String> SendMessage(MessageDTO messageDTO);
        Task<bool> DeleteMessage(int messageId);
        Task<int> UpdateMessage(Message message);
        Task<List<MessageDTO>> GenerateMessagesDTOList(List<Message> messages);
    }
}
