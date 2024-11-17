using MediatR;
using TechGizmos.TechGizmos.Application.Internal.Queries;
using TechGizmos.TechGizmos.Infrastructure.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace TechGizmos.TechGizmos.Application.Internal.Handlers
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdQuery, Item>
    {
        private readonly IItemRepository _repository;

        public GetItemByIdHandler(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Item> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByIdAsync(request.Id);
            if (item == null)
            {
                throw new KeyNotFoundException($"Item with ID {request.Id} not found.");
            }

            return item;
        }
    }
}
