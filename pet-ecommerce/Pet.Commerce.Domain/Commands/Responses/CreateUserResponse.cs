using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Commerce.Domain.Commands.Responses
{
    public class CreateUserResponse : Response
    {
        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Email { get; set; }
    }
}
