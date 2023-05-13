using System;
using System.Collections.Generic;

namespace Pet.Commerce.Domain.Models;

public partial class Categoria
{
    public int Id { get; set; }
    public string Descricao { get; set; } = null!;

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
