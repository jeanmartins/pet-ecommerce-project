using MediatR;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;
using Pet.Commerce.Domain.Services;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            Usuario usu = new Usuario { Administrador = request.Administrador, Email = request.Email, Endereco=request.Endereco, Login=request.Login, Nome=request.Nome, Senha = request.Senha };
            _userRepository.Insert(usu);
            return Task.FromResult(new CreateUserResponse { Nome = "", Endereco = "", Email = "" });
        }

        public Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
           var isUserAutenticate = _userRepository.GetAll().Where(x => x.Login == request.Login && x.Senha == request.Senha).FirstOrDefault();
        if (isUserAutenticate != null)
            {
                var token = TokenService.GenerateToken(isUserAutenticate);
                return Task.FromResult(new LoginUserResponse { Nome = isUserAutenticate.Nome, Token = token , Id = isUserAutenticate.Id}); ;
            }
            return Task.FromResult(new LoginUserResponse() { ErrorMessage = "Usuário ou senha inválidos" });
        }
    }
}
