using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;

namespace Ecommerce.Application.Services;
public class ProductService : IProductService
{
    public Task AddAsync(ProductDto entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ProductDto entity)
    {
        throw new NotImplementedException();
    }
}
