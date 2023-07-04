using MediatR;
using Microsoft.AspNetCore.Http;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;
using System.Security.Claims;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class InsertUserSaleCommandHandler : IRequestHandler<InsertUserSaleCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISalesProductRepository _salesProductRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InsertUserSaleCommandHandler(IProductRepository productRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, ISalesRepository salesRepository, ISalesProductRepository salesProductRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _salesRepository = salesRepository;
            _salesProductRepository = salesProductRepository;
        }

        public Task<bool> Handle(InsertUserSaleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string? userEmail = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;

                if (!string.IsNullOrEmpty(userEmail))
                {
                    var user = _userRepository.GetUserByEmail(userEmail);
                    if (user == null) { return Task.FromResult(false); }
                    if (request.Produtos.Count <= 0) { return Task.FromResult(false); }
                    foreach (var produtoCompra in request.Produtos)
                    {

                        var produto = _productRepository.Get(produtoCompra.IdProduto);
                        if (produto != null)
                        {
                            var venda = new Venda { DataHora = DateTime.Now, Usuario = user, UsuarioId = user.Id };
                            _salesRepository.Insert(venda);
                            var vendaProduto = new VendaProduto { Produto = produto, ProdutoId = produtoCompra.IdProduto = produto.Id, Quantidade = produtoCompra.Quantidade, Venda = venda, VendaId = venda.Id, Preco= produto.Preco };
                            _salesProductRepository.Insert(vendaProduto);

                            var qtd = 0;

                            qtd = produto.Quantidade - produtoCompra.Quantidade;
                            if(qtd < 0) qtd = 0;

                            produto.Quantidade = qtd;
                            _productRepository.Update(produto);
                        }
                    }
                    return Task.FromResult(true);
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
