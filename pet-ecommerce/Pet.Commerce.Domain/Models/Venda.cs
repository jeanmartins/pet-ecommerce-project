using System;
using System.Collections.Generic;

namespace Pet.Commerce.Domain.Models;

public partial class Venda
{
    public int Id { get; set; }

    public DateTime DataHora { get; set; }

    public int UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual ICollection<VendaProduto> VendaProdutos { get; set; } = new List<VendaProduto>();
}
