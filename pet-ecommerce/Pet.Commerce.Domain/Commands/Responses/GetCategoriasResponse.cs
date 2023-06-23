using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Responses
{
    public class GetCategoriasResponse
    {
        public GetCategoriasResponse(Categoria categoria)
        {
            Id = categoria.Id;
            Descricao = categoria.Descricao;
        }

        public int Id { get; set; }
        public string Descricao { get; set; } = null!;
    }
}
