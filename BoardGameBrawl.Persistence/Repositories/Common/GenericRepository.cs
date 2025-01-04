#nullable disable
using BoardGameBrawl.Application.Contracts.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MainAppDBContext _context;
        public GenericRepository(MainAppDBContext context)
        {
            _context = context;
        }
        
        public async Task<T> GetEntity(Guid id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(id);

            return await _context.Set<T>().FindAsync(id, cancellationToken);    
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

        public async Task<T> AddEntity(T entity, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);

            if (!_context.Set<T>().Contains(entity))
            {
                await _context.Set<T>().AddAsync(entity, cancellationToken);
                return entity;
            }
            else
            {
                throw new InvalidOperationException($"Invalid operation - entity cannot be added into the database - already exists");
            }
        }

        public async Task DeleteEntity(T entity, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);

            var entityInDb = await _context.Set<T>().FindAsync(entity, cancellationToken);

            if (entityInDb != null)
            {
                _context.Set<T>().Remove(entity);
            }
            else 
            {
                throw new InvalidOperationException($"Invalid operation: Entity cannot be deleted - not existing in the database");
            }
        }

        public async Task UpdateEntity(T entity, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(entity);

            _context.Entry(entity).State = EntityState.Modified;
            await Task.FromResult<object>(null!);
        }
    }
}
