using Pet.Commerce.Domain.Models;

using Pet.Commerce.Domain.IRepositories;
namespace Pet.Commerce.Infra.Infra.Repositories
{
    public class ProductRepository : Repository<Produto>, IProductRepository
    {
        public ProductRepository(EcommerceContext ecommerceContext) : base(ecommerceContext) { }
    }
}
