using System;
using System.Collections.Generic;

namespace MyWallWebAPI.Domain.Models.DTOs
{
    public class MessageDTO
    {
        public int  ChatId { get; set; }
        public int MessageId { get; set; }
        public string Content { get; set; }
        public string SenderName { get; set; }
        public string SenderId { get; set; }
        public DateTime Data { get; set; }
        public string Footer { get; set; }
        public bool isMine { get; set; } = false;


        public static List<MessageDTO> toListDTO(List<Message> messages)
        {
            List<MessageDTO> messagesDTO = new();
            string footer = "lido por: ";

            foreach (Message message in messages)
            {
                foreach (MessageReceiver messageReceiver in message.MessageReceivers)
                {
                    if (messageReceiver.IsRead == true)
                    {
                        footer += messageReceiver.Receiver.UserName + ", ";
                    }
                }

                messagesDTO.Add(new MessageDTO()
                {
                    ChatId = message.ChatId,
                    MessageId = message.Id,
                    SenderId = message.SenderId,
                    Data = message.Data,
                    Content = message.Content,
                    Footer = footer,
                    SenderName = message.Sender.UserName
                });

                footer = "lidor por: ";
            }

            return messagesDTO;
        }

    }
}
