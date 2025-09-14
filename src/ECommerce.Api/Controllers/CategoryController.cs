using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        else return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
    {
        await _categoryService.AddAsync(categoryDto);
        return CreatedAtAction(nameof(GetById), new { id = categoryDto.Id }, categoryDto);
    }
}
