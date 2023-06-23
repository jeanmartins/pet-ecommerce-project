using MediatR;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int? Id { get; set; }

    }
}
