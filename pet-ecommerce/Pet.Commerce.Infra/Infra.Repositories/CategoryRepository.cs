using Pet.Commerce.Domain.Models;

using Pet.Commerce.Domain.IRepositories;
namespace Pet.Commerce.Infra.Infra.Repositories
{
    public class CategoryRepository : Repository<Categoria>, ICategoryRepository
    {
        public CategoryRepository(EcommerceContext ecommerceContext) : base(ecommerceContext) { }
    }
}
