using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Commerce.Domain.Commands.Responses
{
    public class GetProductsResponse
    {
        public int Id { get; set; }

        public string Descricao { get; set; } = null!;

        public decimal Preco { get; set; }

        public string? Foto { get; set; }

        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }
    }
}
