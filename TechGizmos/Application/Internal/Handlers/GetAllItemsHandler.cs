using MediatR;
using TechGizmos.TechGizmos.Application.Internal.Queries;
using TechGizmos.TechGizmos.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TechGizmos.TechGizmos.Application.Internal.Handlers
{
    public class GetAllItemsHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<Item>>
    {
        private readonly IItemRepository _repository;

        public GetAllItemsHandler(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Item>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
