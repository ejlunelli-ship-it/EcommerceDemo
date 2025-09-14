using Ecommerce.Application.Dtos;

namespace Ecommerce.Application.Interfaces;
public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    Task<CategoryDto?> GetByIdAsync(int id);
    Task AddAsync(CategoryDto entity);
    Task UpdateAsync(CategoryDto entity);
    Task DeleteAsync(int id);
}
