using BlogSite.Models.Dtos.User.Request;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    //[HttpPost("register")]
    //public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
    //{
    //    var result = await _userService.RegisterAsync(dto);
    //    return Ok(result);
    //}

    [HttpGet("getbyemail")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        var result = await _userService.GetByEmailAsync(email);
        return Ok(result);
    }

    //[HttpGet("getall")]
    //public IActionResult GetAll()
    //{
    //    var results = _userService.GetAll();
    //    return Ok(results);
    //}

    //[HttpGet("getbyid/{id}")]
    //public IActionResult GetById([FromRoute] long id)
    //{
    //    var result = _userService.GetById(id);
    //    return Ok(result);
    //}

    //[HttpPost("add")]
    //public IActionResult Add([FromBody] CreateUserRequest createUserRequest)
    //{
    //    var result = _userService.Add(createUserRequest);
    //    return Ok(result);
    //}

    //[HttpDelete("delete")]
    //public IActionResult Remove([FromQuery] long id)
    //{
    //    var result = _userService.Remove(id);
    //    return Ok(result);
    //}

    //[HttpPut("update")]
    //public IActionResult Update([FromBody] UpdateUserRequest updateUserRequest)
    //{
    //    var result = _userService.Update(updateUserRequest);
    //    return Ok(result);
    //}
}
