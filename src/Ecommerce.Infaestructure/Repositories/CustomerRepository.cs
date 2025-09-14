using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infaestructure.Data;

namespace Ecommerce.Infaestructure.Repositories;
public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

}
