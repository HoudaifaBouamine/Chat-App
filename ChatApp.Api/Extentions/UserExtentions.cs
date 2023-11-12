using ChatApp.Api.Entities;
using ChatApp.Models.Dtos.User;
using System.Runtime.CompilerServices;

namespace ChatApp.Api.Extentions
{
    public static class UserExtentions
    {
        public static UserReadDto ToDto(this User user)
        {
            return new UserReadDto()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
            };
        }

        public static UserReadProfileDto ToProfileDto(this User user)
        {
            return new UserReadProfileDto()
            {
                UserId = user.UserId,
                UserName = user.UserName,
            };
        }

        public static IEnumerable<UserReadDto>ToDto(this IEnumerable<User> users)
        {
            return from user in users
                   select new UserReadDto()
                   {
                       UserId = user.UserId,
                       FirstName = user.FirstName,
                       LastName = user.LastName,
                       UserName = user.UserName,
                   };

        }

    }
}
