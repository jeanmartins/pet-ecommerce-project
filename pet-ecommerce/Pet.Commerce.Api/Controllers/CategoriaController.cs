﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;

namespace Pet.Commerce.Api.Controllers
{
    [Route("api/v1/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get")]
        public Task<IEnumerable<GetCategoriasResponse>> GetCategories(GetCategoriasCommand getCategoriesCommand)
        {
            return _mediator.Send(getCategoriesCommand);
        }

        [HttpPost]
        [Route("create")]
        public Task<bool> InsertCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            return _mediator.Send(createCategoryCommand);
        }
        [HttpPost]
        [Route("update")]
        public Task<bool> UpdateCategory([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            return _mediator.Send(updateCategoryCommand);
        }

        [HttpDelete]
        [Route("delete")]
        public Task<bool> DeleteCategory([FromBody] DeleteCategoryCommand deleteCategoryCommand)
        {
            return _mediator.Send(deleteCategoryCommand);
        }
    }
}
