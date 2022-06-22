using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWallWebAPI.Domain.Models;
using MyWallWebAPI.Infrastructure.Data.Contexts;

namespace MyWallWebAPI.Infrastructure.Data.Repositories
{
    public class MessageRepository
    {
        private readonly MySQLContext _context;

        public MessageRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<Message> CreateMessage(Message message)
        {
            var ret = await _context.Message.AddAsync(message);

            await _context.SaveChangesAsync();

            ret.State = EntityState.Detached;

            return ret.Entity;
        }

        public async Task<Message> GetMessageById(int MessageId)
        {
            Message message = await _context.Message.Include(p => p.Sender).Include(p => p.MessageReceivers).FirstOrDefaultAsync((p => p.Id == MessageId));

            return message;
        }

        public async Task<int> UpdateMessage(Message message)
        {
            _context.Entry(message).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteMessageAsync(int messageId)
        {
            var item = await _context.Message.FindAsync(messageId);
            _context.Message.Remove(item);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Message>> ListMessages()
        {
            List<Message> list = await _context.Message.OrderBy(p => p.Data).ToListAsync();

            return list;
        }

        public async Task<List<Message>> ListMessagesByChatId(int ChatId)
        {
            List <Message> messages = await _context.Message.Where(p => p.ChatId == ChatId && p.IsDeletedBySender == false).OrderBy(p => p.Data).Include(p => p.MessageReceivers).Include(p => p.Chat).Include(p => p.Sender).ToListAsync();

            return messages;
        }
    }
}