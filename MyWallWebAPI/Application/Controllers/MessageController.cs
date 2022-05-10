using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWallWebAPI.Domain.Models;
using MyWallWebAPI.Domain.Models.DTOs;
using MyWallWebAPI.Domain.Services.Implementations;
using MyWallWebAPI.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWallWebAPI.Application.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("list-messages")]
        public async Task<ActionResult> ListMessages()
        {
            try
            {
                List<MessageDTO> list = await _messageService.ListMessages();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list-my-sended-messages")]
        public async Task<ActionResult> ListMySendedMessages()
        {
            try
            {
                List<MessageDTO> list = await _messageService.ListMessagesBySenderId();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list-my-received-messages")]
        public async Task<ActionResult> ListMyReceivedMessages()
        {
            try
            {
                List<MessageDTO> list = await _messageService.ListMessagesByReceiverId();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list-my-messages-with-user")]
        public async Task<ActionResult> ListMyMessagesWithUser([FromQuery] string UserId)
        {
            try
            {
                List<MessageDTO> list = await _messageService.ListMessagesByTargetUserId(UserId);

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-message")]
        public async Task<ActionResult> GetMessage([FromQuery] int messageId)
        {
            try
            {
                Message message = await _messageService.GetMessage(messageId);

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("send-message")]
        public async Task<ActionResult> SendMessage([FromBody] MessageDTO messageDTO)
        {
            try
            {
                String message = await _messageService.SendMessage(messageDTO);

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("send-answer")]
        public async Task<ActionResult> SendAnswer([FromBody] AnswerDTO answerDTO)
        {
            try
            {
                String answer = await _messageService.SendAnswer(answerDTO);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-message")]
        public async Task<ActionResult> UpdateMessage([FromBody] Message message)
        {
            try
            {
                return Ok(await _messageService.UpdateMessage(message));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-message")]
        public async Task<ActionResult> DeleteMessage([FromBody] int messageId)
        {
            try
            {
                return Ok(await _messageService.DeleteMessage(messageId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
