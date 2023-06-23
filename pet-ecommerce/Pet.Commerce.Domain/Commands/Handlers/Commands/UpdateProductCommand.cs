using MediatR;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }

    }
}
