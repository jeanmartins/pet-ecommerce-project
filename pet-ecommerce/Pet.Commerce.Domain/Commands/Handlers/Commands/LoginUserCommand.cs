using MediatR;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class LoginUserCommand : IRequest<LoginUserResponse>
    {
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
