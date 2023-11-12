using ChatApp.Api.Data;
using ChatApp.Api.Entities;
using ChatApp.Api.Repositories.Interfaces;

namespace ChatApp.Api.Repositories.Implimentations
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatAppDbContext Database;
        public UserRepository(ChatAppDbContext chatAppDbContext)
        {
            this.Database = chatAppDbContext;
        }

        public User? GetUser(int id)
        {
            return this.Database.Users.Where(u => u.UserId == id).FirstOrDefault();
        }

        public IEnumerable<User>? GetUsers()
        {
            return this.Database.Users.ToList();
        }
    }
}
