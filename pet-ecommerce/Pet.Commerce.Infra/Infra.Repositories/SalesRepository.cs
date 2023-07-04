using Pet.Commerce.Domain.Models;

using Pet.Commerce.Domain.IRepositories;
namespace Pet.Commerce.Infra.Infra.Repositories
{
    public class SalesRepository : Repository<Venda>, ISalesRepository
    {
        public SalesRepository(EcommerceContext ecommerceContext) : base(ecommerceContext) { }
    }
}
