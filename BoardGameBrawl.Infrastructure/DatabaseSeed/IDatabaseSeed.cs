using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Infrastructure.DatabaseSeed
{
    public interface IDatabaseSeed<TDBContext> where TDBContext : DbContext
    {
        public Task SeedDatabaseAsync(TDBContext context);
    }
}
