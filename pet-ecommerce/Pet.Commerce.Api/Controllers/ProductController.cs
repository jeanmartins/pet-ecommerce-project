using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Api.Controllers
{
    [Route("api/v1/product")]
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

        [HttpPost]
        [Route("create")]
        public Task<bool> InsertProduct([FromBody] CreateProductCommand createProductCommand)
        {
            return _mediator.Send(createProductCommand);
        }
        [HttpPost]
        [Route("update")]
        public Task<bool> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand)
        {
            return _mediator.Send(updateProductCommand);
        }

        [HttpDelete]
        [Route("delete")]
        public Task<bool> DeleteProduct([FromBody] DeleteProductCommand deleteProductCommand)
        {
            return _mediator.Send(deleteProductCommand);
        }
    }
}
