using ChatApp.Api.Entities;

namespace ChatApp.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {

        public Task<User?> GetUser(int id);
        public Task<IEnumerable<User>?> GetUsers();
        public Task<User?> GetUser(string username);

    }
}
