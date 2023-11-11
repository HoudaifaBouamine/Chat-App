using ChatApp.Api.Entities;
using ChatApp.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Controllers
{
    [Route("chat/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
    
        private readonly IMessageRepository MessageRepository;
        public MessageController(IMessageRepository messageRepository) 
        {
            this.MessageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return Ok( await MessageRepository.GetMessages() );
        }
        
    }
}
