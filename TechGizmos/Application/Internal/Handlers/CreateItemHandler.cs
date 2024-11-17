using MediatR;
using TechGizmos.TechGizmos.Application.Internal.Commands;
using TechGizmos.TechGizmos.Infrastructure.Repositories;

namespace TechGizmos.TechGizmos.Application.Internal.Handlers
{
    public class CreateItemHandler : IRequestHandler<CreateItemCommand, string>
    {
        private readonly IItemRepository _repository;

        public CreateItemHandler(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = new Item
            {
                Name = request.Name,
                Description = request.Description
            };

            await _repository.AddAsync(item);

            return item.Id; // Devuelve el Id generado.
        }
    }
}
