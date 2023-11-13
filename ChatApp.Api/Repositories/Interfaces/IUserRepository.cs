using ChatApp.Api.Entities;
using ChatApp.Models.Dtos.User;

namespace ChatApp.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {

        public Task<User?> GetUser(int id);
        public Task<IEnumerable<User>?> GetUsers();
        public Task<User?> GetUser(string username);

        public Task<User?> AddNewUser(UserAddDto user);
    }
}
