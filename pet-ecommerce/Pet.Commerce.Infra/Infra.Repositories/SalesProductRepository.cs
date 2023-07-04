using Pet.Commerce.Domain.Models;

using Pet.Commerce.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Pet.Commerce.Infra.Infra.Repositories
{
    public class SalesProductRepository : Repository<VendaProduto>, ISalesProductRepository
    {
        private readonly EcommerceContext _context;

        public SalesProductRepository(EcommerceContext ecommerceContext) : base(ecommerceContext)
        {
            _context = ecommerceContext;
        }

        public ICollection<VendaProduto> GetAllWithProducts()
        {
            return _context.VendaProdutos.Include(vp => vp.Produto).Include(vp => vp.Venda).Include(vp => vp.Venda.Usuario).ToList();
        }



    }
}
