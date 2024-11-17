using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using TechGizmos.TechGizmos.Infrastructure.Repositories;
using TechGizmos.TechGizmos.Application.Internal.Commands;

namespace TechGizmos.TechGizmos.Application.Internal.Handlers
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemCommand, Unit>
    {
        private readonly IItemRepository _repository;

        public DeleteItemHandler(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByIdAsync(request.Id);
            if (item == null)
            {
                throw new KeyNotFoundException($"Item with ID {request.Id} not found.");
            }

            await _repository.DeleteAsync(request.Id);

            return Unit.Value;  // Operación completada exitosamente
        }
    }
}
