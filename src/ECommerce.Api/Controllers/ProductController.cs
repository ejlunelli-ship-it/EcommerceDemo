using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    public ProductController(IProductService productService)
    {
        ProductService = productService;
    }

    public IProductService ProductService { get; }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await ProductService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        else return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDto productDto)
    {
        await ProductService.AddAsync(productDto);
        return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingProduct = await ProductService.GetByIdAsync(id);
        if (existingProduct == null)
        {
            return NotFound();
        }
        await ProductService.DeleteAsync(id);
        return NoContent();
    }
}
