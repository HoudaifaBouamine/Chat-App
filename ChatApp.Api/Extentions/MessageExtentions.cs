using ChatApp.Api.Entities;
using ChatApp.Models.Dtos.Message;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ChatApp.Api.Extentions
{
    public static class MessageExtentions
    {
        public static MessageReadDto ToDto(this Message message,User sender,User receiver)
        {
            return new MessageReadDto()
            {
                MessageId = message.MessageId,
                MessageText = message.MessageText,
                ReceiverId = message.ReceiverId,
                ReceiverUserName = receiver.UserName,
                SenderId = message.SenderId,
                SenderUserName = sender.UserName,
                SendTime = message.SendTime,
            };
        }

        //public static IEnumerable<MessageReadDto> ToDto (this IEnumerable<Message>messages,User? user1,User? user2)
        //{

        //    return from message in messages
        //           select new MessageReadDto()
        //           {

        //               MessageId = message.MessageId,
        //               MessageText = message.MessageText,
        //               SendTime = message.SendTime,

        //               ReceiverId = message.ReceiverId,
        //               ReceiverUserName = GetUserName(message.ReceiverId),

        //               SenderId = message.SenderId,
        //               SenderUserName = GetUserName(message.SenderId),

        //           };


        //    string GetUserName(int? id)
        //    {
        //        if(id == user1.UserId)
        //        {
        //            return user1.UserName;
        //        }
        //        else if(id == user2.UserId)
        //        {
        //            return user2.UserName;
        //        }
        //        else
        //        {
        //            return "Error (User Name Not Found)";
        //        }
        //    }
        //}

        public static IEnumerable<MessageIn2UsersChatDto> ToDto(this IEnumerable<Message> messages, User? user1, User? user2)
        {

            return from message in messages
                   select new MessageIn2UsersChatDto()
                   {

                       MessageId = message.MessageId,
                       MessageText = message.MessageText,
                       SendTime = message.SendTime,

                       SendFromUser1ToUser2 = IsSendFromUser1ToUser2(message.SenderId),
                   };


            bool IsSendFromUser1ToUser2(int? Senderid)
            {
                return user1?.UserId == Senderid;
            }
        }

        public static Message ToEntity(this MessageAddDto messageAddDto)
        {
            Message NewMessage = new Message()
            {
                SenderId = messageAddDto.SenderId,
                ReceiverId = messageAddDto.ReceiverId,
                MessageText = messageAddDto.MessageText,
                SendTime = DateTime.Now,
            };

            return NewMessage;
        }

    }
}
