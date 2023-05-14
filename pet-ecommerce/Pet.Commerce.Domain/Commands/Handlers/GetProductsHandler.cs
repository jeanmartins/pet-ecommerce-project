using MediatR;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsCommand, IEnumerable<GetProductsResponse>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<GetProductsResponse>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            var produtos = _productRepository.GetAll();
            List<GetProductsResponse> result = new List<GetProductsResponse>();
            foreach (var product in produtos)
            {
                result.Add(new GetProductsResponse(product));
            }
            return Task.FromResult(result.AsEnumerable());
        }
    }
}
