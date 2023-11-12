using ChatApp.Api.Entities;

namespace ChatApp.Api.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMessages();
        Task<IEnumerable<Message>> GetMessagesForUser(int id); 
        Task<Message?> GetMessage(int id);
        Task<IEnumerable<Message>?> GetMessagesForUsers(int User_1_Id, int User_2_Id);
        Task<bool> AddMessage(Message message);
    }
}
