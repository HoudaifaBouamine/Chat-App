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

        public static IEnumerable<UserReadProfileDto> GetContacts(this User user, IEnumerable<User> users,IEnumerable<Message> messages)
        {
            // NOTE (Houdaifa) : Update this function later to increase the performence
            //User tmpOtherUser;

            var userContactsReceivedMessages = (
                                from m in messages
                                where m.SenderId == user.UserId
                                select  new UserReadProfileDto()
                                {
                                    UserId = m.ReceiverId.GetValueOrDefault(),
                                    UserName = GetUserById(m.ReceiverId.GetValueOrDefault())?.UserName,
                                }).DistinctBy(u => u.UserId);

            var userContactsSendMessages = (
                                from m in messages
                                where m.ReceiverId == user.UserId
                                select  new UserReadProfileDto()
                                {
                                    UserId = m.SenderId.GetValueOrDefault(),
                                    UserName = GetUserById(m.SenderId.GetValueOrDefault())?.UserName,
                                }).DistinctBy(u => u.UserId);

            var userContacts = userContactsReceivedMessages.Concat(userContactsSendMessages).DistinctBy(u=>u.UserId);

            return userContacts;

            User? GetUserById(int id){

                return (
                        from u in users
                        where u.UserId == id 
                        select u
                        )
                        .FirstOrDefault();
                                             
            }
        }
    }
}
