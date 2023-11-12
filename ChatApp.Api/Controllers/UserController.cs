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
        private readonly IUserRepository _UserRepository;
        public UserController(IUserRepository userRepository)
        {
            this._UserRepository = userRepository;
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
