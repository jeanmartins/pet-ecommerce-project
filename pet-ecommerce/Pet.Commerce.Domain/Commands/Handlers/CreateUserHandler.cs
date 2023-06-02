using MediatR;
using Microsoft.IdentityModel.Tokens;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (_userRepository.GetUserByEmail(request.Email) != null)
                {
                    return Task.FromResult(new CreateUserResponse { ErrorMessage = "Usuário já cadastrado no sistema" });
                }
                if (!string.IsNullOrEmpty(request.Email) && !string.IsNullOrEmpty(request.Endereco) && !string.IsNullOrEmpty(request.Nome) && !string.IsNullOrEmpty(request.Senha))
                {
                    Usuario usu = new Usuario { Administrador = request.Administrador, Email = request.Email, Endereco = request.Endereco, Login = Guid.NewGuid().ToString("N"), Nome = request.Nome, Senha = request.Senha };
                    _userRepository.Insert(usu);
                    return Task.FromResult(new CreateUserResponse { Nome = usu.Nome, Endereco = usu.Endereco, Email = usu.Email });
                }
                return Task.FromResult(new CreateUserResponse { ErrorMessage = "Ocorreu um erro ao cadastrar usuário" });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CreateUserResponse { ErrorMessage = "Ocorreu um erro ao cadastrar usuário" });

            }
        }
    }
}
