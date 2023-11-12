using ChatApp.Api.Data;
using ChatApp.Api.Entities;
using ChatApp.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Api.Repositories.Implimentations
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatAppDbContext Database;
        public UserRepository(ChatAppDbContext chatAppDbContext)
        {
            this.Database = chatAppDbContext;
        }

        public async Task<User?> GetUser(int id)
        {
            return await this.Database.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUser(string username)
        {
            return await this.Database.Users.Where(u=>u.UserName == username).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>?> GetUsers()
        {
            return await this.Database.Users.ToListAsync();
        }
    }
}
