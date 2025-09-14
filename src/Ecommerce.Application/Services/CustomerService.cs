using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;

namespace Ecommerce.Application.Services;
public class CustomerService : ICustomerService
{
    public Task AddAsync(CustomerDto entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CustomerDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CustomerDto entity)
    {
        throw new NotImplementedException();
    }
}
