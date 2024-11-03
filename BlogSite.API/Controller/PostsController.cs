using BlogSite.Models.Dtos.Post.Request;
using BlogSite.Models.Dtos.Post.Response;
using BlogSite.Service.Abstracts;
using Core.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogSite.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet("GetAll")]
    [Authorize(Roles = "User")]
    public IActionResult GetAll()
    {
        var result = _postService.GetAll();
        return Ok(result);
    }

    [HttpPost("Add")]
    public IActionResult Add(CreatePostRequest createPostRequest)
    {
        var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = _postService.Add(createPostRequest, userId);
        return Ok(result);
    }

    [HttpGet("getById/{id}")]
    //[Authorize(Roles = "Admin")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _postService.GetById(id);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public IActionResult Remove([FromQuery] Guid id)
    {
        var result = _postService.Remove(id);
        return Ok(result);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] UpdatePostRequest updatePostRequest)
    {
        var result = _postService.Update(updatePostRequest);
        return Ok(result);
    }

    //[HttpGet("author")]
    //public IActionResult GetAllByAuthorId([FromQuery] long id)
    //{
    //    var results = _postService.GetAllByAuthorId(id);
    //    return Ok(results);
    //}
}