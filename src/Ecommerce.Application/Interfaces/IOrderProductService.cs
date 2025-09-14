using Ecommerce.Application.Dtos;

namespace Ecommerce.Application.Interfaces;
public interface IOrderProductService
{
    Task<IEnumerable<OrderProductDto>> GetAllAsync();
    Task<OrderProductDto?> GetByIdAsync(int id);
    Task AddAsync(OrderProductDto entity);
    Task UpdateAsync(OrderProductDto entity);
    Task DeleteAsync(int id);
}
