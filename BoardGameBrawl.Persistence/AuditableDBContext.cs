using BoardGameBrawl.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence
{
    public abstract class AuditableDBContext : DbContext
    {
        public AuditableDBContext(DbContextOptions options) : base(options)
        {

        }

        public virtual async Task<int> SaveChangesAsync(string username = "SYSADM", CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<ISoftDeleted>()
               .Where(e => e.State == EntityState.Deleted))
            {
                entry.State = EntityState.Modified;
                entry.Property(nameof(ISoftDeleted.IsSoftDeleted)).CurrentValue = true;    
            }

            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                entry.Entity.LastModifiedBy = username;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = username;
                }
            }
            
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
