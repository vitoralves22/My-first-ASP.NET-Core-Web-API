using MyWallWebAPI.Domain.Models;
using MyWallWebAPI.Domain.Services.Interfaces;
using MyWallWebAPI.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallWebAPI.Domain.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly MessageRepository _messageRepository;
        private readonly IAuthService _authService;

        public MessageService(MessageRepository MessageRepository, IAuthService authService, IPostService postService)
        {
            _authService = authService;
            _messageRepository = MessageRepository;
        }

        public async Task<List<Message>> ListMessages()
        {
            List<Message> list = await _messageRepository.ListMessages();

            return list;
        }

        public async Task<List<Message>> ListMySendedMessages()
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            List<Message> list = await _messageRepository.ListMessagesBySenderId(currentUser.Id);

            return list;
        }

        public async Task<List<Message>> ListMyReceivedMessages()
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            List<Message> list = await _messageRepository.ListMessagesByReceiverId(currentUser.Id);

            return list;
        }


        public async Task<Message> GetMessageById(int MessageId)
        {
            Message Message = await _messageRepository.GetMessageById(MessageId);

            if (Message == null)
                throw new ArgumentException("Message não existe!");

            return Message;
        }

        public async Task<Message> SendMessage(Message Message)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();
            ApplicationUser receiver = await _authService.GetUserById(Message.ReceiverId);

            Message newMessage = new();

            newMessage.SenderId = currentUser.Id;
            newMessage.ReceiverId = receiver.Id;
            newMessage.Data = DateTime.Now;
            newMessage.Content = Message.Content;

            newMessage = await _messageRepository.CreateMessage(newMessage);

            return newMessage;
        }

        public async Task<bool> DeleteMessage(int messageId)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            Message findMessage = await _messageRepository.GetMessageById(messageId);

            if (findMessage == null)
                throw new ArgumentException("Message não existe!");


            await _messageRepository.DeleteMessageAsync(findMessage.Id);

            return true;
        }

        public async Task<int> UpdateMessage(Message message)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            Message findMessage = await _messageRepository.GetMessageById(message.Id);
            if (findMessage == null)
                throw new ArgumentException("Message não existe!");

            if (!findMessage.SenderId.Equals(currentUser.Id))
                throw new ArgumentException("Sem permissão.");

            findMessage.Content = message.Content;

            return await _messageRepository.UpdateMessage(findMessage);
        }

    }
}
