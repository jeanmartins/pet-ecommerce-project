using System;
using System.Collections.Generic;

namespace Pet.Commerce.Domain.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public bool Administrador { get; set; }

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}
