using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TechGizmos.TechGizmos.Infrastructure.Repositories;
using System.Threading;
using System.Threading.Tasks;
using TechGizmos.TechGizmos.Application.Internal.Commands;

namespace TechGizmos.TechGizmos.Application.Internal.Handlers
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemCommand, Unit>
    {
        private readonly IItemRepository _repository;

        public UpdateItemHandler(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByIdAsync(request.Id);
            if (item == null)
            {
                throw new KeyNotFoundException($"Item with ID {request.Id} not found.");
            }

            item.Name = request.Name;
            item.Description = request.Description;

            await _repository.UpdateAsync(item);

            return Unit.Value;  // Indica que la operación se completó con éxito
        }
    }
}
