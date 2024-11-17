using MediatR;

namespace TechGizmos.TechGizmos.Application.Internal.Commands
{
    public class CreateItemCommand : IRequest<string> // Debe retornar string
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
