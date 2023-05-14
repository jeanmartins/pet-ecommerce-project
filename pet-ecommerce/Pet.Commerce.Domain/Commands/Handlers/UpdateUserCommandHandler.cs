using MediatR;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<CreateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var usu = _userRepository.Get(request.Id);
            if (usu == null) { return Task.FromResult(new CreateUserResponse() { ErrorMessage = "Ocorreu um erro ao atualizar usuário" }); }
            usu.Nome = !string.IsNullOrEmpty(request.Nome) ? request.Nome : usu.Nome;
            usu.Email = !string.IsNullOrEmpty(request.Email) ? request.Email : usu.Email;
            usu.Endereco = !string.IsNullOrEmpty(request.Endereco) ? request.Endereco : usu.Endereco;
            usu.Senha = !string.IsNullOrEmpty(request.Senha) ? request.Senha : usu.Senha;
            _userRepository.Update(usu);
            return Task.FromResult(new CreateUserResponse() { Nome = usu.Nome, Email = usu.Email, Endereco = usu.Endereco });
        }
    }
}
