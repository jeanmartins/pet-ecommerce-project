using Pet.Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Commerce.Domain.IRepositories
{
    public interface IUserRepository : IRepository<Usuario>
    {
        public Usuario GetUserByEmail(string email);
    }
}
