using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;

namespace Ecommerce.Application.Services;
public class CategoryService : ICategoryService
{
    public Task AddAsync(CategoryDto entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CategoryDto entity)
    {
        throw new NotImplementedException();
    }
}
