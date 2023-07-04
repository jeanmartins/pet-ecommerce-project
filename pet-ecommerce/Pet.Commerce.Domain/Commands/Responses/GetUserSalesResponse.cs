using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Responses
{
    public class GetUserSalesResponse
    {
        public GetUserSalesResponse(Produto product, int quantidade, int idPedido, decimal preco, string user = "")
        {
            Id = idPedido;
            Descricao = product.Descricao;
            Preco = preco;
            Foto = product.Foto;
            Quantidade = quantidade;
            Usuario = user;
        }

        public int Id { get; set; }

        public string Descricao { get; set; } = null!;
        public string Usuario { get; set; } = "";

        public decimal Preco { get; set; }

        public string? Foto { get; set; }

        public int Quantidade { get; set; }
    }
}
