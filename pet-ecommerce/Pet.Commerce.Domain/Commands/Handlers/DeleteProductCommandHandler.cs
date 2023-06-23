using MediatR;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id == null)
                    return Task.FromResult(false);

                var product = _productRepository.Get(request.Id.Value);
                if (product != null)
                {
                    return Task.FromResult(_productRepository.Delete(product));
                }

                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);

            }

        }
    }
}
