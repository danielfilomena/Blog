using Blog.Application.Dtos;
using Blog.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase 
    {

        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet("getAllPost")]
        public async Task<IActionResult> GetAllPost()
            => Ok(await _service.GetAllPost());

        [Authorize]
        [HttpPost("createPost")]
        public async Task<IActionResult> CreatePost(PostDto dto)
            => Ok(await _service.SavePost(dto));

    }
}
