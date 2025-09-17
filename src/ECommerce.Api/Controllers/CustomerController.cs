using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByid(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer == null)
        {
            return new NotFoundResult();
        }
        return new OkObjectResult(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerService.GetAllAsync();
        return new OkObjectResult(customers);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CustomerDto customerDto)
    {
        await _customerService.AddAsync(customerDto);
        return new CreatedAtActionResult(nameof(GetByid), "Customer", new { id = customerDto.Id }, customerDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingCustomer = await _customerService.GetByIdAsync(id);
        if (existingCustomer == null)
        {
            return new NotFoundResult();
        }
        await _customerService.DeleteAsync(id);
        return new NoContentResult();
    }
}
