using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Api.Controllers
{
    [Route("ap1/v1/product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get")]
        public Task<IEnumerable<GetProductsResponse>> GetProducts(GetProductsCommand getProductsCommand)
        {
            return _mediator.Send(getProductsCommand);
        }
    }
}
