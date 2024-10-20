using BlogSite.Models.Dtos.Category.Request;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class Categories : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public Categories(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var results = _categoryService.GetAll();
        return Ok(results);
    }

    [HttpDelete("delete")]
    public IActionResult Remove([FromQuery] int id)
    {
        var result = _categoryService.Remove(id);
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add(CreateCategoryRequest createCategoryRequest)
    {
        var result = _categoryService.Add(createCategoryRequest);
        return Ok(result);
    }

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var result = _categoryService.GetById(id);
        return Ok(result);
    }
    
    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdateCategoryRequest updateCategoryRequest)
    {
        var result = _categoryService.Update(updateCategoryRequest);
        return Ok(result);
    }

    

}
