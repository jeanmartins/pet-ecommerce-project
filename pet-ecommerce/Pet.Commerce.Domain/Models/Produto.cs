using System;
using System.Collections.Generic;

namespace Pet.Commerce.Domain.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public decimal Preco { get; set; }

    public string? Foto { get; set; }

    public int Quantidade { get; set; }

    public int CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<VendaProduto> VendaProdutos { get; set; } = new List<VendaProduto>();
}
