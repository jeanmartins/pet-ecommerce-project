using MediatR;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id == null)
                    return Task.FromResult(false);

                var categoria = _categoryRepository.Get(request.Id.Value);
                if (categoria != null)
                {
                    return Task.FromResult(_categoryRepository.Delete(categoria));
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
