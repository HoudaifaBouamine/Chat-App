using ChatApp.Api.Data;
using ChatApp.Api.Entities;
using ChatApp.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Api.Repositories.Implimentations
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatAppDbContext Database;
        public MessageRepository(ChatAppDbContext database)
        {
            this.Database = database;
        }

        public async Task<Message?> GetMessage(int id)
        {
            Message? message = await Database.Messages.Where(m => m.MessageId == id).FirstOrDefaultAsync();
            return message;
        }

        public async Task<IEnumerable<Message>> GetMessages()
        {
            IEnumerable<Message> messages = await Database.Messages.ToListAsync();
            return messages;
        }

        public async Task<IEnumerable<Message>?> GetMessagesForUsers(int User_1_Id, int User_2_Id)
        {
            return await this.Database.Messages.Where(
                m => 
                ((m.SenderId == User_1_Id && m.ReceiverId == User_2_Id) 
                ||
                (m.SenderId == User_2_Id && m.ReceiverId == User_1_Id)) 
                ).ToListAsync();
        }
    }
}
