namespace BoardGameBrawl.Application.Contracts.Common
{
    public interface IGenericRepository<T> where T : class
    {
        // standard entities - represented by singular primary key
        Task<T> GetEntity(Guid id, CancellationToken cancellationToken = default);

        // junction exntities - represented by composed primary keys
        Task<T> GetEntity(object[] keys, CancellationToken cancellationToken = default);

        Task<IList<T>> GetBatchOfEntities(int size, int skip = 0, CancellationToken cancellationToken = default);

        Task<IList<T>> GetAllEntities(CancellationToken cancellationToken = default);

        Task<object[]> GetPrimaryKeys(T entity, CancellationToken cancellation = default);

        Task AddEntity(T entity, CancellationToken cancellationToken = default);

        // standard entities - represented by singular primary key
        Task<bool> Exists(Guid id, CancellationToken cancellationToken = default);

        // junction exntities - represented by composed primary keys
        Task<bool> Exists(object[] keys, CancellationToken cancellationToken = default);

        Task<int> CountTotalElements(CancellationToken cancellationToken = default);

        Task<bool> AnyElements(CancellationToken cancellationToken = default);

        Task DeleteEntity(T entity, CancellationToken cancellationToken = default);

        Task UpdateEntity(T entity, CancellationToken cancellationToken = default);

        void AttachEntity(T entity, CancellationToken cancellationToken = default);

        void DetachEntity(T entity, CancellationToken cancellationToken = default);
    }
}