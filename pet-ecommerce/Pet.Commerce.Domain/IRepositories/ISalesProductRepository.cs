using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.IRepositories
{
    public interface ISalesProductRepository : IRepository<VendaProduto>
    {
        public ICollection<VendaProduto> GetAllWithProducts();
    }
}
