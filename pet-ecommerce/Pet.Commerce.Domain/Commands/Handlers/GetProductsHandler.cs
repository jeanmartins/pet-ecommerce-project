using MediatR;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsCommand, IList<GetProductsResponse>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        //public Task<IList<CreateUserResponse>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        //{

        //    var list = _productRepository.Get();

        //    return Task.FromResult(new CreateUserResponse { Nome = "", Endereco = "", Email = "" });
        //}

        Task<IList<GetProductsResponse>> IRequestHandler<GetProductsCommand, IList<GetProductsResponse>>.Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
