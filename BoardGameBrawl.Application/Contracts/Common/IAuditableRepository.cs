using BoardGameBrawl.Domain.Common;

namespace BoardGameBrawl.Application.Contracts.Common
{
    public interface IAuditableRepository<T> where T : BaseAuditableEntity
    {
        // getter methods // 

        public async Task<DateTimeOffset> GetCreatedDateAsync(T entity,
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

        public async Task<DateTimeOffset> GetLastModifiedDateAsync(T entity,
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
          DateTimeOffset creationDateTime,
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
            DateTimeOffset modificationDateTime,
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
