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
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("list-chat")]
        public async Task<ActionResult> ListPosts()
        {
            try
            {
                List<ChatDTO> list = await _chatService.ListChat();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list-messages-from-chat")]
        public async Task<ActionResult> ListMessagesInChat([FromQuery] int chatId)
        {
            try
            {
                List<MessageDTO> chat = await _chatService.ListMessagesInChat(chatId);

                return Ok(chat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("initiate-chat")]
        public async Task<ActionResult> CreateChat([FromBody] List<string> users)
        {
            try
            {
                String chat = await _chatService.IniciateChat(users);

                return Ok(chat);
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
                String message = await _chatService.SendMessage(messageDTO);

                return Ok(message);
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
                return Ok(await _chatService.DeleteMessage(messageId));
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
                return Ok(await _chatService.UpdateMessage(message));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-chat")]
        public async Task<ActionResult> GetChat([FromQuery] int chatId)
        {
            try
            {

                return Ok(await _chatService.GetChat(chatId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
