using MyWallWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Services.Interfaces
{
    public interface IMessageService
    {
        Task<List<Message>> ListMessages();
        Task<List<Message>> ListMySendedMessages();
        Task<List<Message>> ListMyReceivedMessages();
        Task<Message> GetMessageById(int MessageId);
        Task<int> UpdateMessage(Message message);
        Task<bool> DeleteMessage(int messageId);
    }
}
