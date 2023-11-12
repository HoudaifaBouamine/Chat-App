using ChatApp.Api.Entities;
using ChatApp.Api.Repositories.Interfaces;
using ChatApp.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}
