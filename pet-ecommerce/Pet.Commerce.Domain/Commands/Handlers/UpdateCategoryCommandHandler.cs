using MediatR;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.IRepositories;

namespace Pet.Commerce.Domain.Commands.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id == null) return Task.FromResult(false);
                var category = _categoryRepository.Get(request.Id.Value);
                if (category == null) return Task.FromResult(false);

                category.Descricao = request.Descricao;

                _categoryRepository.Update(category);
                return Task.FromResult(true);

            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }

        }
    }
}
