#nullable disable
using BoardGameBrawl.Application.Contracts.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MainAppDBContext _context;
        public GenericRepository(MainAppDBContext context)
        {
            _context = context;
        }

        // exposing MainAppDBContext to derived repository classes //
        protected MainAppDBContext Context => _context;
        
        public async Task<T> GetEntity(Guid id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(id);

            return await _context.Set<T>().FindAsync(id, cancellationToken);    
        }

        public async Task<ICollection<T>> GetBatchOfEntities(int size, int skip = 0, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (size <= 0)
                throw new ArgumentException("Batch size must be greater than zero.", nameof(size));

            try
            {
                return await _context.Set<T>()
                    .Skip(skip)
                    .Take(size)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving a batch of entities.", ex);
            }
        }

        public async Task<ICollection<T>> GetAllEntities(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<bool> Exists(Guid id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(id);

            var entity = await _context.Set<T>().FindAsync(id, cancellationToken);
            return entity != null;
        }

        public async Task AddEntity(T entity, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);

            // Assuming the primary key(s) can be extracted
            var keyValues = _context.Model.FindEntityType(typeof(T))?
                .FindPrimaryKey()?
                .Properties
                .Select(p => p.PropertyInfo?.GetValue(entity))
                .ToArray();

            if (keyValues == null || keyValues.Contains(null))
            {
                throw new InvalidOperationException("Unable to determine the primary key value(s) for the entity.");
            }

            var entityInDB = await _context.Set<T>().FindAsync(keyValues, cancellationToken);

            if (entityInDB == null)
            {
                await _context.Set<T>().AddAsync(entity, cancellationToken);
            }
        }

        public async Task DeleteEntity(T entity, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);

            // Assuming the primary key(s) can be extracted
            var keyValues = _context.Model.FindEntityType(typeof(T))?
                .FindPrimaryKey()?
                .Properties
                .Select(p => p.PropertyInfo?.GetValue(entity))
                .ToArray();

            if (keyValues == null || keyValues.Contains(null))
            {
                throw new InvalidOperationException("Unable to determine the primary key value(s) for the entity.");
            }

            var entityInDb = await _context.Set<T>().FindAsync(keyValues, cancellationToken);

            if (entityInDb != null)
            {
                _context.Set<T>().Remove(entity);
            }
            else 
            {
                throw new InvalidOperationException($"Invalid operation: Entity cannot be deleted - not existing in the database");
            }
        }

        public Task UpdateEntity(T entity, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);

            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
