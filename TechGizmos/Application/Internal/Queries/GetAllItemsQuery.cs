using MediatR;
using System.Collections.Generic;

namespace TechGizmos.TechGizmos.Application.Internal.Queries
{
    public record GetAllItemsQuery() : IRequest<IEnumerable<Item>>;
}
