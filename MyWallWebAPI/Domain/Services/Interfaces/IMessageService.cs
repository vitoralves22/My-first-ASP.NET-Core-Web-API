using MyWallWebAPI.Domain.Models;
using MyWallWebAPI.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Services.Interfaces
{
    public interface IMessageService
    {
        Task<List<MessageDTO>> ListMessages();
        Task<List<MessageDTO>> ListMessagesBySenderId();
        Task<List<MessageDTO>> ListMessagesByReceiverId();
        Task<Message> GetMessage(int MessageId);
        Task<int> UpdateMessage(Message message);
        Task<Message> SendMessage(MessageDTO message);
        Task<Message> SendAnswer(AnswerDTO answer);
        Task<bool> DeleteMessage(int messageId);
        Task<List<MessageDTO>> GenerateMessagesDTOList(List<Message> messages);
    }
}
