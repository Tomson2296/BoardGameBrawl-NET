using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.Contracts.Entities.Group_Related;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Entities.Group_Related;
using BoardGameBrawl.Persistence.Repositories.Entities.Player_Related;

using Microsoft.Extensions.DependencyInjection;

namespace BoardGameBrawl.Persistence
{
    public static class RegisterPersistenceLayerServices
    {
        public static Task<IServiceCollection> RegisterPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add Player-Related repositories

            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IGroupParticipantRepository, GroupParticipantRepository>();
            services.AddScoped<IPlayerPreferenceRepository, PlayerPreferenceRepository>();

            // Add Boardgames-Related repositories

            services.AddScoped<IBoardgameRepository, BoardgameRepository>();
            services.AddScoped<IBoardgameCategoriesRepository, BoardgameCategoriesRepository>();
            services.AddScoped<IBoardgameCategoryTagsRepository, BoardgameCategoryTagsRepository>();
            services.AddScoped<IBoardgameMechanicsRepository, BoardgameMechanicsRepository>();
            services.AddScoped<IBoardgameMechanicTagsRepository, BoardgameMechanicTagsRepository>();

            // Add Group-Related repositories

            services.AddScoped<IGroupRepository, GroupRepository>();


            return Task.FromResult(services);
        }
    }
}
