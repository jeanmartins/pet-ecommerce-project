using MediatR;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public string? Foto { get; set; }

        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }
    }
}
