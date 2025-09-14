using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infaestructure.Data;

namespace Ecommerce.Infaestructure.Repositories;
public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
