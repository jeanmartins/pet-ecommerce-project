using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Api.Controllers
{
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public Task<CreateUserResponse> CreateUser([FromBody] CreateUserCommand command)
        {
            return _mediator.Send(command);
        }
        [HttpPost]
        [Route("login")]
        public Task<LoginUserResponse> LoginUser([FromBody] LoginUserCommand command) { 
            return _mediator.Send(command);
        }
        [HttpPost]
        [Route("updateUser")]
        [Authorize]
        public Task<CreateUserResponse> UpdateUser([FromBody] UpdateUserCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpDelete]
        [Route("deleteUser")]
        [Authorize]
        public Task<bool> DeleteUser([FromBody] DeleteUserCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpGet]
        [Route("getProfile/{Email}")]
        [Authorize]
        public Task<GetProfileResponse> GetProfile(GetProfileCommand command)
        {
            return _mediator.Send(command);
        }
        [HttpGet]
        [Route("getUserSales")]
        [Authorize]
        public Task<IEnumerable<GetUserSalesResponse>> GetUserSales (GetUserSalesCommand command)
        {
            return _mediator.Send(command);
        }
        [HttpPost]
        [Route("insertUserSales")]
        [Authorize]
        public Task<bool> InsertUserSale( [FromBody] InsertUserSaleCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpGet]
        [Route("getAllUserSales")]
        [Authorize]
        public Task<IEnumerable<GetUserSalesResponse>> GetAllUserSales(GetAllUsersSalesCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpDelete]
        [Route("deleteUserSale")]
        [Authorize]
        public Task<bool> DeleteUserSale([FromBody] DeleteUserSaleCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
