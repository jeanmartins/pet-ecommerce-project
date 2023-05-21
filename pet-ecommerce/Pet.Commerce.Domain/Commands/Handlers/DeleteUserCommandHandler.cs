using MediatR;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            Usuario? usu = null;
            if (!string.IsNullOrEmpty(request.Email))
               usu = _userRepository.GetUserByEmail(request.Email);

            if (usu != null)
            {
                return Task.FromResult(_userRepository.Delete(usu));
            }
            return Task.FromResult(false);
        }
    }
}
