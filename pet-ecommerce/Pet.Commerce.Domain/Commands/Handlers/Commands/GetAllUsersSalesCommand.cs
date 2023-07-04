using MediatR;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class GetAllUsersSalesCommand : IRequest<IEnumerable<GetUserSalesResponse>>
    {

    }
}
