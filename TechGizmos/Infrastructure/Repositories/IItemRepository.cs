namespace TechGizmos.TechGizmos.Infrastructure.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> GetByIdAsync(string id); // Cambia de int a string
        Task AddAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(string id); // Cambia de int a string
        Task<Item> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
