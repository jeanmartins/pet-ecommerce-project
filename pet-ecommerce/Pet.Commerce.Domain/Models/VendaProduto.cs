using System;
using System.Collections.Generic;

namespace Pet.Commerce.Domain.Models;

public partial class VendaProduto
{
    public int VendaId { get; set; }

    public int ProdutoId { get; set; }

    public int Quantidade { get; set; }

    public decimal Preco { get; set; }

    public virtual Produto Produto { get; set; } = null!;

    public virtual Venda Venda { get; set; } = null!;
}
