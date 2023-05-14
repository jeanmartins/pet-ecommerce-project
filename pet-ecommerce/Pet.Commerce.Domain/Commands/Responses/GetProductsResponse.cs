using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Responses
{
    public class GetProductsResponse
    {
        public GetProductsResponse(Produto product)
        {
            Id = product.Id;
            Descricao = product.Descricao;
            Preco = product.Preco;
            Foto = product.Foto;
            Quantidade = product.Quantidade;
            CategoriaId = product.CategoriaId;
        }

        public int Id { get; set; }

        public string Descricao { get; set; } = null!;

        public decimal Preco { get; set; }

        public string? Foto { get; set; }

        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }
    }
}
