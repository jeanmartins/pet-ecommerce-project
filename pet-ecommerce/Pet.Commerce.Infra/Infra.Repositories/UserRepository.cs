using Pet.Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pet.Commerce.Domain.IRepositories;
namespace Pet.Commerce.Infra.Infra.Repositories
{
    public class UserRepository : Repository<Usuario>, IUserRepository
    {
        private readonly EcommerceContext _context;
        public UserRepository(EcommerceContext ecommerceContext) : base(ecommerceContext) {
        _context = ecommerceContext;
        }

        public Usuario GetUserByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(usu => usu.Email == email);
        }
    }
}
