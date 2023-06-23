using MediatR;

namespace Pet.Commerce.Domain.Commands.Handlers.Requests
{
    public class CreateCategoryCommand : IRequest<bool>
    {
        public string Descricao { get; set; }
    }
}
