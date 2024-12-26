using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Helpers.Exceptions.Category;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(_categoryService.GetAllAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] AddCategoryDto addCategoryDto)
    {
        try
        {
            await _categoryService.AddAsync(addCategoryDto);
            return StatusCode(201, addCategoryDto);
        }
        catch (CategoryAlreadyExistsException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCategoryDto updateCategoryDto)
    {
        try
        {
            await _categoryService.UpdateAsync(id, updateCategoryDto);
            return Ok("Category updated");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("SoftDelete/{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        try
        {
            await _categoryService.SoftDeleteAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}