using MediatR;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class InsertUserSaleCommand : IRequest<bool>
    {
        public List<Compra> Produtos { get; set; }
    }
}
