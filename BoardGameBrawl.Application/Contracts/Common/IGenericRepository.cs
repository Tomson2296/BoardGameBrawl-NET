namespace BoardGameBrawl.Application.Contracts.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(Guid id);

        Task<ICollection<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task<bool> Exists(Guid id);

        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);
    }
}
