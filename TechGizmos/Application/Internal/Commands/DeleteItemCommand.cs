using MediatR;

namespace TechGizmos.TechGizmos.Application.Internal.Commands
{
    public record DeleteItemCommand(string Id) : IRequest<Unit>;
}
