using MediatR;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public string? Email { get; set; } = "";

    }
}
