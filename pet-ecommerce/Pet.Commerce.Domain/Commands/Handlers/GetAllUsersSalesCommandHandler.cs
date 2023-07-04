using MediatR;
using Microsoft.AspNetCore.Http;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using System.Security.Claims;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class GetAllUsersSalesCommandHandler : IRequestHandler<GetAllUsersSalesCommand, IEnumerable<GetUserSalesResponse>>
    {
        private readonly ISalesProductRepository _salesProductRepository;

        public GetAllUsersSalesCommandHandler(ISalesProductRepository salesProductRepository)
        {
            _salesProductRepository = salesProductRepository;
        }

        public Task<IEnumerable<GetUserSalesResponse>> Handle(GetAllUsersSalesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<GetUserSalesResponse> list = new List<GetUserSalesResponse>();
                var vendas = _salesProductRepository.GetAllWithProducts().ToList();
                foreach (var venda in vendas)
                {
                    var v = new GetUserSalesResponse(venda.Produto, venda.Quantidade, venda.VendaId, venda.Preco, venda.Venda.Usuario.Nome);
                    list.Add(v);
                }
                return Task.FromResult(list.AsEnumerable());
            }
            catch (Exception ex)
            {
                return Task.FromResult(new List<GetUserSalesResponse>().AsEnumerable());
            }
        }
    }
}
