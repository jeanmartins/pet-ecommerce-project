using MediatR;
using Microsoft.AspNetCore.Http;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;
using Pet.Commerce.Domain.Services;
using System.Security.Claims;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class GetProfileCommandHandler : IRequestHandler<GetProfileCommand, GetProfileResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetProfileCommandHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<GetProfileResponse> Handle(GetProfileCommand request, CancellationToken cancellationToken)
        {
            var userEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

            if(!string.IsNullOrEmpty(userEmail) && !string.IsNullOrEmpty(request.Email) && userEmail == request.Email)
            {
                var user = _userRepository.GetUserByEmail(userEmail);
                return Task.FromResult(new GetProfileResponse { Email = user.Email, Endereco = user.Endereco, Nome = user.Nome, Senha = user.Senha, Admin = user.Administrador });
            }
            return Task.FromResult(new GetProfileResponse() { ErrorMessage = "Ocorreu um erro ao realizar essa requisição" });
        }
    }
}
