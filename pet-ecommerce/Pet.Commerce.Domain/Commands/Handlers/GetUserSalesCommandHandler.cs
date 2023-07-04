using MediatR;
using Microsoft.AspNetCore.Http;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using System.Security.Claims;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class GetUserSalesCommandHandler : IRequestHandler<GetUserSalesCommand, IEnumerable<GetUserSalesResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISalesProductRepository _salesProductRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserSalesCommandHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, ISalesProductRepository salesProductRepository)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _salesProductRepository = salesProductRepository;
        }

        public Task<IEnumerable<GetUserSalesResponse>> Handle(GetUserSalesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string? userEmail = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;

                List<GetUserSalesResponse> list = new List<GetUserSalesResponse>();
                if (!string.IsNullOrEmpty(userEmail))
                {
                    var user = _userRepository.GetUserByEmail(userEmail);
                    var vendas = _salesProductRepository.GetAllWithProducts().Where(x => x.Venda.UsuarioId == user.Id).ToList();
                    foreach ( var venda in vendas )
                    {
                        var v = new GetUserSalesResponse(venda.Produto, venda.Quantidade, venda.VendaId, venda.Preco);
                        list.Add(v);
                    }
                    
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
