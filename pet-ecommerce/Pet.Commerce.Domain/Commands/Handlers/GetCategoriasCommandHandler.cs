using MediatR;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class GetCategoriasCommandHandler : IRequestHandler<GetCategoriasCommand, IEnumerable<GetCategoriasResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoriasCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<IEnumerable<GetCategoriasResponse>> Handle(GetCategoriasCommand request, CancellationToken cancellationToken)
        {
            var categorias = _categoryRepository.GetAll();
            List<GetCategoriasResponse> result = new List<GetCategoriasResponse>();
            foreach (var categoria in categorias)
            {
                result.Add(new GetCategoriasResponse(categoria));
            }
            return Task.FromResult(result.AsEnumerable());
        }
    }
}
