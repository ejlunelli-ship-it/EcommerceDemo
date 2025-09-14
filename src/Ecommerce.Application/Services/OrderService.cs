using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;

namespace Ecommerce.Application.Services;
public class OrderService : IOrderService
{
    public Task AddAsync(OrderDto entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(OrderDto entity)
    {
        throw new NotImplementedException();
    }
}
