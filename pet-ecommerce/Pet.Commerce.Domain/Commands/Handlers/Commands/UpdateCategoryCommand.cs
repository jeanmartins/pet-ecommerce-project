using MediatR;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }

    }
}
