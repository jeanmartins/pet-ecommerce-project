using MediatR;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _productRepository.Insert(new Produto { CategoriaId = request.CategoriaId, Descricao = request.Descricao, Foto = !string.IsNullOrEmpty(request.Foto) ? request.Foto: "https://cobasi.vteximg.com.br/arquivos/ids/939212/racao-golden-formula-caes-adultos-racas-pequenas-frango-arroz-mini-bits-3626279-1kg.jpg?v=638127640641870000", Preco = request.Preco, Quantidade = request.Quantidade });
                if (result != null)
                    return Task.FromResult(true);
                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
