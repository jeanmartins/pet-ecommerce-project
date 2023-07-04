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
        public Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
           var isUserAutenticate = _userRepository.GetAll().Where(x => x.Email == request.Email && x.Senha == request.Senha).FirstOrDefault();
        if (isUserAutenticate != null)
            {
                var token = TokenService.GenerateToken(isUserAutenticate);
                return Task.FromResult(new LoginUserResponse { Nome = isUserAutenticate.Nome, Token = token , Id = isUserAutenticate.Id, Role = isUserAutenticate.Administrador}); ;
            }
            return Task.FromResult(new LoginUserResponse() { ErrorMessage = "Usuário ou senha inválidos" });
        }
    }
}
