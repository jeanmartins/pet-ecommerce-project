using MediatR;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class GetUserSalesCommand : IRequest<IEnumerable<GetUserSalesResponse>>
    {

    }
}
