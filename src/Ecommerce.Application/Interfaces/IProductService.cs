using Ecommerce.Application.Dtos;

namespace Ecommerce.Application.Interfaces;
public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetByIdAsync(int id);
    Task AddAsync(ProductDto entity);
    Task UpdateAsync(ProductDto entity);
    Task DeleteAsync(int id);
}
