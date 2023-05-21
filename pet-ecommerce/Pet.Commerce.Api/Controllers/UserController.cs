using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Api.Controllers
{
    [Route("ap1/v1/user")]
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
    }
}
