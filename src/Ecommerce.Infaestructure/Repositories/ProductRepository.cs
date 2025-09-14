using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infaestructure.Data;

namespace Ecommerce.Infaestructure.Repositories;
public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
