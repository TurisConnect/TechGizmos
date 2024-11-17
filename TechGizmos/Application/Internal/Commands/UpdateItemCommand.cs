using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TechGizmos.TechGizmos.Application.Internal.Commands
{
    public record UpdateItemCommand(string Id, string Name, string Description) : IRequest<Unit>;


}
