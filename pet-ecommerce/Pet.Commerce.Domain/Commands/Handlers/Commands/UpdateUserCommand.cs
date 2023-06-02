using MediatR;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class UpdateUserCommand : IRequest<CreateUserResponse>
    {
        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Email { get; set; }
        public string Senha { get; set; }

    }
}
