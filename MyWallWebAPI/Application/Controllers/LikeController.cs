using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWallWebAPI.Domain.Models;
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
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet("list-likes")]
        public async Task<ActionResult> ListLikes()
        {
            try
            {
                List<LikeDTO> list = await _likeService.ListLikes();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list-likes-by-current-user")]
        public async Task<ActionResult> ListLikesByCurrentUser()
        {
            try
            {
                List<LikeDTO> list = await _likeService.ListLikesByCurrentUser();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list-likes-by-post")]
        public async Task<ActionResult> ListLikesByPost([FromQuery] int postId)
        {
            try
            {
                List<LikeDTO> list = await _likeService.ListLikesByPost(postId);

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-like")]
        public async Task<ActionResult> GetLike([FromQuery] int likeId)
        {
            try
            {
                Like like = await _likeService.GetLike(likeId);

                return Ok(like);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("do-like")]
        public async Task<ActionResult> DoLike([FromBody] int postId)
        {
            try
            {
                return Ok(await _likeService.DoLike(postId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("undo-like")]
        public async Task<ActionResult> UndoLike([FromBody] int postId)
        {
            try
            {
                return Ok(await _likeService.UndoLike(postId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("count-likes-by-post")]
        public async Task<ActionResult> CountLikes([FromQuery] int postId)
        {
            try
            {
                return Ok(await _likeService.GetCountOfLikesInAPost(postId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
