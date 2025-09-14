using Ecommerce.Application.Dtos;

namespace Ecommerce.Application.Interfaces;
public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<CustomerDto?> GetByIdAsync(int id);
    Task AddAsync(CustomerDto entity);
    Task UpdateAsync(CustomerDto entity);
    Task DeleteAsync(int id);
}
