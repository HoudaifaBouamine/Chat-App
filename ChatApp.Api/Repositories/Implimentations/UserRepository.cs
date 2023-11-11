using ChatApp.Api.Data;
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
    }
}
