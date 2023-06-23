using MediatR;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class GetCategoriasCommand : IRequest<IEnumerable<GetCategoriasResponse>>
    {
    }
}
