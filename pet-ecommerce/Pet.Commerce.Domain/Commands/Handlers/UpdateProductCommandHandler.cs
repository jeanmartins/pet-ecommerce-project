using MediatR;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

       public Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id == null) return Task.FromResult(false);

                var product = _productRepository.Get(request.Id.Value);
                if (product == null) return Task.FromResult(false);

                product.Preco = request.Preco != 0 && request.Preco != null ? request.Preco : product.Preco;
                product.Descricao = !string.IsNullOrEmpty(request.Descricao) ? request.Descricao : product.Descricao;
                product.CategoriaId = request.CategoriaId != null ? request.CategoriaId : product.CategoriaId;
                product.Quantidade = request.Quantidade != 0 && request.Quantidade != null ? request.Quantidade : product.Quantidade;

                _productRepository.Update(product);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
