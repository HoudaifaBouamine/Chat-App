﻿using ChatApp.Api.Entities;
using ChatApp.Api.Extentions;
using ChatApp.Api.Repositories.Implimentations;
using ChatApp.Api.Repositories.Interfaces;
using ChatApp.Models.Dtos.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
       

        [HttpGet("{User_1_Name}/{User_2_Name}/{User_1_PinCode}")]
        public async Task<ActionResult<IEnumerable<MessageIn2UsersChatDto>>> GetMessagesBetween (string User_1_Name, string User_2_Name ,string User_1_PinCode)
        {
            User? user1 = await _UserRepository.GetUser(User_1_Name);

            if(user1 == null)
            {
                return NotFound("User 1 Not Found");
            }

            User? user2 = await _UserRepository.GetUser(User_2_Name);

            if(user2 == null)
            {
                return NotFound("User 2 Not Found");
            }

            if(user1?.PinCode != User_1_PinCode)
            {
                return BadRequest("PinCode is Wrong");
            }

            IEnumerable<Message>? messages = await _MessageRepository.GetMessagesForUsers(user1.UserId, user2.UserId);

            if(messages == null || messages.Count() == 0)
            {
                return NotFound($"There is Not Messages Between [{user1.UserName}] & [{user2.UserName}]");
            }

            IEnumerable<MessageIn2UsersChatDto>? messagesAsDtos = messages?.ToDto(user1, user2);

            if (messagesAsDtos == null || messagesAsDtos.Count() == 0)
            {
                return NotFound();
            }

            return Ok(messagesAsDtos);
        }


        [HttpPost]
        public async Task<ActionResult> PostMessage([FromBody] MessageAddDto messageAddDto)
        {
           
            try
            {
                if (messageAddDto == null)
                {
                    return BadRequest("Invalid JSON payload. body");
                }

                string message = messageAddDto.MessageText.ToString();

                if(message == "")
                {
                    return BadRequest("Message Can not be Empty");
                }

                User? Sender = await  this._UserRepository.GetUser(messageAddDto.SenderId.GetValueOrDefault());
                if(Sender == null)
                {
                    return NotFound("Sender Not Found");
                }
                User? Receiver = await this._UserRepository.GetUser(messageAddDto.ReceiverId.GetValueOrDefault());
                if (Receiver == null)
                {
                    return NotFound("Receiver Not Found");
                }


                if (Sender.PinCode != messageAddDto.SenderPinCode)
                {
                    return BadRequest("Sender Pin Code is Wrong");
                }

                Message NewMessage = messageAddDto.ToEntity();

                bool isSendSuccessfuly = await this._MessageRepository.AddMessage(NewMessage);

                if(!isSendSuccessfuly)
                {
                    return BadRequest("Failed To Send The Message");
                }

                // NOTE (Houdaifa) : write Code here to insert the new message to the database
                

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        
        
        // Not Ready

        [HttpGet("{User_1_Id}/{User_2_Id}")]
        private async Task<ActionResult<IEnumerable<MessageIn2UsersChatDto>>> GetMessagesBetween(int User_1_Id, int User_2_Id)
        {
            User? user1 = await _UserRepository.GetUser(User_1_Id);
            User? user2 = await _UserRepository.GetUser(User_2_Id);
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
