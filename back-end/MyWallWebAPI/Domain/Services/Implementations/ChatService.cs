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
    public class ChatService : IChatService
    {
        private readonly ChatRepository _chatRepository;
        private readonly MessageRepository _messageRepository;
        private readonly IAuthService _authService;

        public ChatService(MessageRepository messageRepository, ChatRepository ChatRepository, IAuthService authService)
        {
            _authService = authService;
            _chatRepository = ChatRepository;
            _messageRepository = messageRepository;
        }

        public async Task<List<ChatDTO>> ListChat()
        {
            List<Chat> list = await _chatRepository.ListChat();
            List<ChatDTO> result = ChatDTO.toListDTO(list);

            foreach (ChatDTO chatDTO in result)
            {
                List<string> names = new();
                List<ChatUser> chatUsers = await _chatRepository.GetChatUsersByChatId(chatDTO.ChatId);
                foreach (ChatUser chatUser in chatUsers)
                {
                    names.Add(chatUser.ApplicationUser.UserName);
                }
                chatDTO.ChatMembers = names;
            }

            return result;
        }

        public async Task<Chat> GetChat(int chatId)
        {
            Chat chat = await _chatRepository.GetChatById(chatId);

            if (chat == null)
                throw new ArgumentException("Post não existe!");

            return chat;
        }




        public async Task<List<MessageDTO>> ListMessagesInChat(int ChatId)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();
            List<Message> messagesFinded = await _messageRepository.ListMessagesByChatId(ChatId);
            List<ChatUser> chatUsers = await _chatRepository.GetChatUsersByChatId(ChatId);

            List<Message> messagesNotDeleted = new();
            List<MessageDTO> messagesDTO = new();
            ChatDTO chatDTO = new();
            chatDTO.ChatMembers = new List<string>();
            chatDTO.ChatId = ChatId;

            foreach (ChatUser chatUser in chatUsers)
            {
                chatDTO.ChatMembers.Add(chatUser.ApplicationUser.UserName);
            }

            foreach (Message message in  messagesFinded)
            {
                if (message.Sender != currentUser)
                {
                    foreach (MessageReceiver messageReceiver in message.MessageReceivers)
                    {
                        if (messageReceiver.Receiver == currentUser)
                        {
                            if (messageReceiver.IsRead == false)
                            {
                                messageReceiver.IsRead = true;
                                await _messageRepository.UpdateMessage(message);
                            }

                            if (messageReceiver.IsDeletedByReceiver == false)
                            {
                                messagesNotDeleted.Add(message);
                            }
                        }
                    }
                }
                else
                {
                    messagesNotDeleted.Add(message);  
                }             
            }

            messagesDTO = MessageDTO.toListDTO(messagesNotDeleted);

            foreach (MessageDTO messageDTO in messagesDTO)
            {
                if(messageDTO.SenderId == currentUser.Id)
                {
                    messageDTO.isMine = true;
                }
            }

            return messagesDTO;
        }

        public async Task<String> IniciateChat(List<string> usersId)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            Chat chat = new ();
            chat.ChatUsers = new();
            chat.Initiator = currentUser;     
         
            chat.ChatUsers.Add(new ChatUser() { 
                ApplicationUser = currentUser
            });
           
            var userIdHash = new HashSet<string>(usersId);
            var value = usersId.Count - userIdHash.Count;

            if (value > 0)
            {
                throw new ArgumentException("Não adicione usuários repetidos em um mesmo chat");
            }

            foreach (string userId in usersId)
            {
                if (userId == currentUser.Id)
                {
                    throw new ArgumentException("Você não precisa se adicionar à um chat onde você é o iniciador!");
                }

                ApplicationUser user = await _authService.GetUserById(userId);

                if (user != null)
                {
                    ChatUser ChatUser = new();
                    ChatUser.ApplicationUser = user;
                    ChatUser.ApplicationUserId = user.Id;
                    chat.ChatUsers.Add(ChatUser);
                }
            }

            chat.Data = DateTime.Now;

            await _chatRepository.CreateChat(chat);

            return "Chat criado";
        }

        public async Task<String> SendMessage(MessageDTO messageDTO)
        {
            Chat chat = await _chatRepository.GetChatById(messageDTO.ChatId);
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            Message message = new()
            {
                Chat = chat,
                Content = messageDTO.Content,
                Sender = currentUser,
                Data = DateTime.Now,
            };

            message.MessageReceivers = new();

            foreach (ChatUser chatUser in chat.ChatUsers)
            {
                if (chatUser.ApplicationUserId != message.Sender.Id)
                {
                    MessageReceiver messageReceiver = new();
                    messageReceiver.IsDeletedByReceiver = false;
                    messageReceiver.IsRead = false;
                    messageReceiver.Receiver = chatUser.ApplicationUser;
                    messageReceiver.ReceiverId = chatUser.ApplicationUserId;
                    message.MessageReceivers.Add(messageReceiver);

                }
            }

            await _messageRepository.CreateMessage(message);

            return "Mensagem enviada";
        }

        public async Task<bool> DeleteMessage(int messageId)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();
            Message message = await _messageRepository.GetMessageById(messageId);
            Chat chat = await _chatRepository.GetChatById(message.ChatId);

            bool IsInChat = false;

            if (message == null)
                throw new ArgumentException("Mensagem não existe!");


            if (chat == null)
                throw new ArgumentException("Chat não existe!");

            foreach (ChatUser chatUser in chat.ChatUsers) 
            { 
                if(chatUser.ApplicationUserId == currentUser.Id)
                {
                    IsInChat = true;
                }
            }

            if (IsInChat == false)
                throw new ArgumentException("Usuário não pertence a este chat!");


            foreach (MessageReceiver messageReceiver in message.MessageReceivers)
            {
                if(messageReceiver.Receiver == currentUser)
                {
                    messageReceiver.IsDeletedByReceiver = true;
                    await _messageRepository.UpdateMessage(message);
                }
            }

            if(message.Sender == currentUser)
            {
                message.IsDeletedBySender = true;
                await _messageRepository.UpdateMessage(message);
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

            findMessage.Content = message.Content;

            return await _messageRepository.UpdateMessage(findMessage);
        }

       
    }
}
