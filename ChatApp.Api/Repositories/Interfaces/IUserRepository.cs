using ChatApp.Api.Entities;

namespace ChatApp.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {

        public User? GetUser(int id);
        public IEnumerable<User>? GetUsers();

    }
}
