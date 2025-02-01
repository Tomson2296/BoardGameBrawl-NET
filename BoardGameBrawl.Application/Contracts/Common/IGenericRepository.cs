namespace BoardGameBrawl.Application.Contracts.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetEntity(Guid id, CancellationToken cancellationToken = default);

        Task<ICollection<T>> GetBatchOfEntities(int size, int skip = 0, CancellationToken cancellationToken = default);

        Task<ICollection<T>> GetAllEntities(CancellationToken cancellationToken = default);

        Task AddEntity(T entity, CancellationToken cancellationToken = default);
        
        Task<bool> Exists(Guid id, CancellationToken cancellationToken = default);

        Task DeleteEntity(T entity, CancellationToken cancellationToken = default);

        Task UpdateEntity(T entity, CancellationToken cancellationToken = default);

        void AttachEntity(T entity, CancellationToken cancellationToken = default);

        void DetachEntity(T entity, CancellationToken cancellationToken = default);
    }
}
