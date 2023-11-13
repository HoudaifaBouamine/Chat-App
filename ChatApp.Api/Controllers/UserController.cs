using ChatApp.Api.Entities;
using ChatApp.Api.Extentions;
using ChatApp.Api.Repositories.Interfaces;
using ChatApp.Models.Dtos;
using ChatApp.Models.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ChatApp.Api.Controllers
{
    [Route("chat/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository    _UserRepository   ;
        private readonly IMessageRepository _MessageRepository;
        public UserController(IUserRepository userRepository,IMessageRepository messageRepository)
        {
            this._UserRepository = userRepository;
            this._MessageRepository = messageRepository;
        }

        [HttpGet("{userName}/{pinCode}")]
        public async Task<ActionResult<UserReadDto>> GetUser(string userName,string pinCode)
        {
            User? user = await this._UserRepository.GetUser(userName);

            if(user == null)
            {
                return NotFound();
            }

            if(user.PinCode == pinCode)
            {
                return Ok(user.ToDto());
            }
            else
            {
                return BadRequest("Pin Code is Wrong !");
            }

        }
        
        [HttpGet("{userName}")]
        public async Task<ActionResult<UserReadProfileDto>> GetUser(string userName)
        {
            User? user = await this._UserRepository.GetUser(userName);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToDto());

        }


        [HttpGet("{userName}/Contacts")]
        public async Task<ActionResult<UserReadProfileDto>> GetUserContacts(string userName)
        {


            var users = await this._UserRepository.GetUsers();

            if(users == null)
            {
                return NotFound("There is No User on the system");
            }


            User? user = await this._UserRepository.GetUser(userName);

            if (user == null)
            {
                return NotFound("User Not Found");
            }


            IEnumerable<Message> messages = await this._MessageRepository.GetMessagesForUser(user.UserId);

            if(messages.Count() == 0)
            {
                return NotFound("User Have no contacts");
            }

            IEnumerable<UserReadProfileDto> Contacts = user.GetContacts(users, messages);

            return Ok( Contacts );
        }


        [HttpPost]
        public async Task<ActionResult<UserReadDto>> RegisterUser([FromBody] UserAddDto userAsAddDto)
        {
            User? userAsEntity = await this._UserRepository.GetUser(userAsAddDto.UserName);

            if(userAsEntity != null)
            {
                return BadRequest("User Name is Taken");
            }

            userAsEntity = await this._UserRepository.AddNewUser(userAsAddDto);

            if(userAsEntity == null)
            {
                return BadRequest("Failed To Add User");
            }

            return userAsEntity.ToDto();
        }

        // Not Ready

        [HttpGet("{UserName_Or_UserId}")]
        private async Task<ActionResult<UserReadDto>> _GetUserGeneric(string UserName_Or_UserId)
        {
            if (UserName_Or_UserId.IsNullOrEmpty())
            {
                return BadRequest("How you can even send NULL or Empty String here ????");
            }

            int UserId;
            User? user = null;

            if (int.TryParse(UserName_Or_UserId, out UserId))
            {
                // This Line will execute if the entered user name were in integer format, so it represent the user id
                user = await this._UserRepository.GetUser(UserId);
            }
            else
            {
                string UserName = UserName_Or_UserId; 
                // This Line will execute if the entered user name were string (not in integer format) so it represent the userName
                user = await this._UserRepository.GetUser(UserName);
            }


            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user.ToDto());
            }
        }

    }
}
