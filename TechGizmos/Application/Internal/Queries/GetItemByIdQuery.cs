using MediatR;

namespace TechGizmos.TechGizmos.Application.Internal.Queries
{
    public record GetItemByIdQuery(string Id) : IRequest<Item>;
}
