using MediatR;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int? Id { get; set; }

    }
}
