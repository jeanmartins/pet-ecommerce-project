using MediatR;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class DeleteUserSaleCommand : IRequest<bool>
    {
        public int VendaId { get; set; } = 0;

    }
}
