using MyWallWebAPI.Domain.Models;
using MyWallWebAPI.Domain.Models.DTOs;
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

        public MessageService(MessageRepository MessageRepository, IAuthService authService)
        {
            _authService = authService;
            _messageRepository = MessageRepository;
        }

        public async Task<List<MessageDTO>> ListMessages()
        {
            List<Message> list = await _messageRepository.ListMessages();
            List<MessageDTO> dtos = await GenerateMessagesDTOList(list);

            return dtos;
        }

        public async Task<List<MessageDTO>> ListMessagesBySenderId()
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            List<Message> list = await _messageRepository.ListMessagesBySenderId(currentUser.Id);

            return await GenerateMessagesDTOList(list);
        }

        public async Task<List<MessageDTO>> ListMessagesByReceiverId()
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            List<Message> receivedMesssages = await _messageRepository.ListMessagesByReceiverId(currentUser.Id);

            foreach(Message message in receivedMesssages)
            {
                if (message.IsRead == false)
                {
                    message.IsRead = true;
                    await _messageRepository.UpdateMessage(message);
                }
            }

            return await GenerateMessagesDTOList(receivedMesssages);
        }

        public async Task<List<MessageDTO>> ListMessagesByTargetUserId(string userId)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();
            List<Message> chat = await _messageRepository.ListMessagesBetweenUsers(currentUser.Id, userId); ;
             
            foreach (Message message in chat)
            {
                if (message.IsRead == false)
                {
                    message.IsRead = true;
                    await _messageRepository.UpdateMessage(message);
                }
            }

            List<MessageDTO> chatDTO = await GenerateMessagesDTOList(chat);

            return chatDTO;
        }

        public async Task<Message> GetMessage(int MessageId)
        {
            Message Message = await _messageRepository.GetMessageById(MessageId);

            if (Message == null)
                throw new ArgumentException("Mensagem não existe!");

            if(Message.IsRead == false)
            {
                Message.IsRead = true;
                await _messageRepository.UpdateMessage(Message);
            }

            return Message;
        }

        public async Task<String> SendMessage(MessageDTO messageDTO)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();
            ApplicationUser receiver = await _authService.GetUserById(messageDTO.ReceiverId);

            if (receiver == null)
                throw new ArgumentException("Usuário não encontrado!");

            if (messageDTO.ReceiverId == currentUser.Id)
                throw new ArgumentException("Você não pode enviar mensagem para você mesmo!");

            if(messageDTO.Content == null)
                throw new ArgumentException("Você não pode enviar uma mensagem vazia!");

            Message message = new()
            {
                Content = messageDTO.Content,
                Header = "Mensagem enviada por: " + currentUser.UserName,
                SenderId = currentUser.Id,
                ReceiverId = receiver.Id,
                Data = DateTime.Now,
                IsAnswer = false,
                IsRead = false,
                IsDeletedBySender = false,
                IsDeletedByReceiver = false  
            };

            await _messageRepository.CreateMessage(message);

            return "Mensagem Enviada";
        }

        public async Task<String> SendAnswer(AnswerDTO answerDTO)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();
            Message message = await _messageRepository.GetMessageById(answerDTO.MessageId);

            if(message.SenderId == currentUser.Id)
                throw new ArgumentException("Você não pode responder sua própria mensagem!");

            if (answerDTO.Content == null)
                throw new ArgumentException("Você não pode enviar uma mensagem vazia!");

            Message answer = new()
            {
                Header = "Resposta enviada por: " + currentUser.UserName,
                SenderId = currentUser.Id,
                ReceiverId = message.SenderId,
                Content = answerDTO.Content,
                Data = DateTime.Now,
                IsAnswer = true,
                IsRead = false
            };

            await _messageRepository.CreateMessage(answer);

            return "Resposta Enviada";
        }

        public async Task<bool> DeleteMessage(int messageId)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();
            Message findMessage = await _messageRepository.GetMessageById(messageId);

            if (findMessage == null)
                throw new ArgumentException("Mensagem não existe!");

            if ((findMessage.ReceiverId != currentUser.Id) && (findMessage.SenderId != currentUser.Id))
                throw new ArgumentException("Sem permissão!");

            if ((findMessage.SenderId == currentUser.Id) && (findMessage.IsRead == false))
                await _messageRepository.DeleteMessageAsync(findMessage.Id);

            if ((findMessage.SenderId == currentUser.Id) && (findMessage.IsRead == true)) 
            {
                findMessage.IsDeletedBySender = true;
                await _messageRepository.UpdateMessage(findMessage);
            }

            if (findMessage.ReceiverId == currentUser.Id)
            {
                findMessage.IsDeletedByReceiver = true;
                await _messageRepository.UpdateMessage(findMessage);
            }

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

            if (findMessage.IsRead == true)
                throw new ArgumentException("A mensagem já foi lida.");

            findMessage.Content = message.Content;

            return await _messageRepository.UpdateMessage(findMessage);
        }

        public async Task<List<MessageDTO>> GenerateMessagesDTOList(List<Message> messages)
        {
            List<MessageDTO> messagesDTO = new();
           
            foreach (Message message in messages)
            {
               
                messagesDTO.Add(new MessageDTO()
                {
                    MessageId = message.Id,
                    Header = message.Header,
                    SenderId = message.SenderId,
                    ReceiverId = message.ReceiverId,
                    Data = message.Data,
                    Content = message.Content,
                    IsRead = message.IsRead
                });

            }

            return messagesDTO;
        }

        public async Task<int> compare(int a, int b)
        {
            if (a < b) {
                return -1;
            }
            if (a > b) {
                return 1;
            }
            return 0;
        }

    }
}
