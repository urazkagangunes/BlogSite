using BlogSite.Models.Dtos.Post.Request;
using BlogSite.Models.Dtos.Post.Response;
using BlogSite.Service.Abstracts;
using Core.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Posts : ControllerBase
    {
        private readonly IPostService _postService;

        public Posts(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetAll")]
        public ActionResult<ReturnModel<List<PostResponseDto>>> GetAll()
        {
            var result = _postService.GetAll();
            return Ok(result);
        }

        [HttpPost("Add")]
        public ActionResult<ReturnModel<PostResponseDto>> Add(CreatePostRequest createPostRequest)
        {
            var result = _postService.Add(createPostRequest);
            return Ok(result);
        }

        [HttpGet("getById{id}")]
        public ActionResult<ReturnModel<PostResponseDto>> GetById(Guid id)
        {
            var result = _postService.GetById(id);
            return Ok(result);
        }
    }
}
