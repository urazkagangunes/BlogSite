using BlogSite.Models.Dtos.Comment.Request;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class Comments : ControllerBase
{
    private readonly ICommentService _commentService;

    public Comments(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var results = _commentService.GetAll();
        return Ok(results);
    }

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var  result = _commentService.GetById(id);
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CreateCommentRequest createCommentRequest)
    {
        var result = _commentService.Add(createCommentRequest);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public IActionResult Remove([FromQuery] Guid id)
    {
        var result = _commentService.Remove(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdateCommentRequest updateCommentRequest)
    {
        var result = _commentService.Update(updateCommentRequest);
        return Ok(result);
    }

}
