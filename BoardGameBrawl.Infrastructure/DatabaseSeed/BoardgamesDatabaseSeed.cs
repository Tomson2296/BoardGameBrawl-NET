using BoardGameBrawl.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Infrastructure.DatabaseSeed
{
    public class BoardgamesDatabaseSeed : IDatabaseSeed<MainAppDBContext>
    {
        public Task SeedDatabaseAsync(MainAppDBContext context)
        {
            return Task.CompletedTask;
        }
    }
}
