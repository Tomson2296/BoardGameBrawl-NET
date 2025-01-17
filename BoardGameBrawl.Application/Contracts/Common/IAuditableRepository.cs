using BoardGameBrawl.Domain.Common;

namespace BoardGameBrawl.Application.Contracts.Common
{
    public interface IAuditableRepository<T> where T : BaseEntity
    {
        // getter methods // 

        public async Task<DateTime> GetCreatedDateAsync(T entity,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);

            return await Task.FromResult(entity.CreatedDate);
        }

        public async Task<string?> GetCreatedByAsync(T entity,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);

            return await Task.FromResult(entity.CreatedBy);
        }

        public async Task<DateTime> GetLastModifiedDateAsync(T entity,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);

            return await Task.FromResult(entity.LastModifiedDate);
        }

        public async Task<string?> GetLastModifiedByAsync(T entity,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);

            return await Task.FromResult(entity.LastModifiedBy);
        }

        // setter methods //

        public Task SetCreatedDateAsync(T entity,
          DateTime creationDateTime,
          CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);
            ArgumentNullException.ThrowIfNull(creationDateTime);

            entity.CreatedDate = creationDateTime;
            return Task.CompletedTask;
        }

        public Task SetCreatedByAsync(T entity,
            string? createdBy,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);
            ArgumentNullException.ThrowIfNull(createdBy);

            entity.CreatedBy = createdBy;
            return Task.CompletedTask;
        }

        public Task SetLastModifiedDateAsync(T entity,
            DateTime modificationDateTime,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);
            ArgumentNullException.ThrowIfNull(modificationDateTime);

            entity.LastModifiedDate = modificationDateTime;
            return Task.CompletedTask;
        }

        public Task SetLastModifiedByAsync(T entity,
            string? lastModifiedBy,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);
            ArgumentNullException.ThrowIfNull(lastModifiedBy);

            entity.LastModifiedBy = lastModifiedBy;
            return Task.CompletedTask;
        }
    }
}
