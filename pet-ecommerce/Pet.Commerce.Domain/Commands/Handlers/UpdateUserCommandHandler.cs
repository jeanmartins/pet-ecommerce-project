using MediatR;
using Microsoft.AspNetCore.Http;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;
using System.Security.Claims;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateUserCommandHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task<CreateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!string.IsNullOrEmpty(userEmail) && !string.IsNullOrEmpty(request.Email) && userEmail == request.Email)
                {
                    var usu = _userRepository.GetUserByEmail(userEmail);
                    usu.Nome = !string.IsNullOrEmpty(request.Nome) ? request.Nome : usu.Nome;
                    usu.Email = !string.IsNullOrEmpty(request.Email) ? request.Email : usu.Email;
                    usu.Endereco = !string.IsNullOrEmpty(request.Endereco) ? request.Endereco : usu.Endereco;
                    usu.Senha = !string.IsNullOrEmpty(request.Senha) ? request.Senha : usu.Senha;
                    _userRepository.Update(usu);
                    return Task.FromResult(new CreateUserResponse() { Nome = usu.Nome, Email = usu.Email, Endereco = usu.Endereco });
                }
                return Task.FromResult(new CreateUserResponse() { ErrorMessage = "Ocorreu um erro ao atualizar usuário" });
            }
            catch(Exception ex)
            {
                return Task.FromResult(new CreateUserResponse() { ErrorMessage = "Ocorreu um erro ao atualizar usuário" });
            }

        }
    }
}
