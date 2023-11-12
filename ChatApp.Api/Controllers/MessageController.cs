using ChatApp.Api.Entities;
using ChatApp.Api.Extentions;
using ChatApp.Api.Repositories.Implimentations;
using ChatApp.Api.Repositories.Interfaces;
using ChatApp.Models.Dtos.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Controllers
{
    [Route("chat/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
    
        private readonly IMessageRepository _MessageRepository;
        private readonly IUserRepository _UserRepository;
        public MessageController(IMessageRepository messageRepository, IUserRepository userRepository) 
        {
            this._MessageRepository = messageRepository;
            this._UserRepository = userRepository;
        }
       

        [HttpGet("{User_1_Id}/{User_2_Id}")]
        public async Task<ActionResult<IEnumerable<MessageIn2UsersChatDto>>> GetMessagesBetween(int User_1_Id, int User_2_Id)
        {
            User? user1 = _UserRepository.GetUser(User_1_Id);
            User? user2 = _UserRepository.GetUser(User_2_Id);
            IEnumerable<Message>? messages = await _MessageRepository.GetMessagesForUsers(User_1_Id, User_2_Id);

            IEnumerable<MessageIn2UsersChatDto>? messagesAsDtos = messages?.ToDto(user1, user2);

            if(messagesAsDtos == null || messagesAsDtos.Count() == 0)
            {
                return NotFound();
            }

            return Ok( messagesAsDtos );
        }
    }
}
