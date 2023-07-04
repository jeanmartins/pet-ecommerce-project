using MediatR;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class DeleteUserSaleCommandHandler : IRequestHandler<DeleteUserSaleCommand, bool>
    {
        private readonly ISalesProductRepository _salesProductRepository;
        public DeleteUserSaleCommandHandler(ISalesProductRepository salesProductRepository)
        {
            _salesProductRepository = salesProductRepository;
        }
        public Task<bool> Handle(DeleteUserSaleCommand request, CancellationToken cancellationToken)
        {
            VendaProduto? vendaProduto = null;
            if (request.VendaId > 0)
                vendaProduto = _salesProductRepository.GetAllWithProducts().FirstOrDefault(v => v.VendaId == request.VendaId);

            if (vendaProduto != null)
            {
                return Task.FromResult(_salesProductRepository.Delete(vendaProduto));
            }
            return Task.FromResult(false);
        }
    }
}
