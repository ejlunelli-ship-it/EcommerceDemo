using Ecommerce.Application.Dtos;

namespace Ecommerce.Application.Interfaces;
public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllAsync();
    Task<OrderDto?> GetByIdAsync(int id);
    Task AddAsync(OrderDto entity);
    Task UpdateAsync(OrderDto entity);
    Task DeleteAsync(int id);
}
