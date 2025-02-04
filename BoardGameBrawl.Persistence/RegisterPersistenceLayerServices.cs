using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.Contracts.Entities.Group_Related;
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.Repositories.Common;
using BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Entities.Group_Related;
using BoardGameBrawl.Persistence.Repositories.Entities.Player_Related;
using BoardGameBrawl.Persistence.Services;
using BoardGameBrawl.Persistence.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGameBrawl.Persistence
{
    public static class RegisterPersistenceLayerServices
    {
        public static Task<IServiceCollection> RegisterPersistenceServices(this IServiceCollection services)
        {
            // Register IGenericRepositories and both versions of UnitOfWork 
            // one for every DBContext

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register Player-Related repositories

            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IGroupParticipantRepository, GroupParticipantRepository>();
            services.AddScoped<IPlayerPreferenceRepository, PlayerPreferenceRepository>();

            // Register Boardgames-Related repositories

            services.AddScoped<IBoardgameRepository, BoardgameRepository>();
            services.AddScoped<IBoardgameCategoriesRepository, BoardgameCategoriesRepository>();
            services.AddScoped<IBoardgameCategoryTagsRepository, BoardgameCategoryTagsRepository>();
            services.AddScoped<IBoardgameMechanicsRepository, BoardgameMechanicsRepository>();
            services.AddScoped<IBoardgameMechanicTagsRepository, BoardgameMechanicTagsRepository>();

            // Register Group-Related repositories

            services.AddScoped<IGroupRepository, GroupRepository>();

            // Register Custom Identity Stores

            services.AddScoped<IApplicationUserStore<ApplicationUser>, ApplicationUserStore>();
            services.AddScoped<IApplicationRoleStore<ApplicationRole>, ApplicationRoleStore>();

            //services.AddScoped<IUserEmailStore<ApplicationUser>, ApplicationUserStore>();
            //services.AddScoped<IUserClaimStore<ApplicationUser>, ApplicationUserStore>();
            //services.AddScoped<IUserConfirmation<ApplicationUser>, ApplicationUserStore>();
            //services.AddScoped<IUserLockoutStore<ApplicationUser>, ApplicationUserStore>();
            //services.AddScoped<IUserLoginStore<ApplicationUser>, ApplicationUserStore>();
            //services.AddScoped<IUserPasswordStore<ApplicationUser>, ApplicationUserStore>();
            //services.AddScoped<IUserRoleStore<ApplicationUser>, ApplicationUserStore>();
            //services.AddScoped<IUserSecurityStampStore<ApplicationUser>, ApplicationUserStore>();
            //services.AddScoped<IRoleClaimStore<ApplicationRole>, ApplicationRoleStore>();

            // Register ApplicationUserQuery Service
            services.AddScoped<IApplicationUserQueryService, ApplicationUserQueryService>();

            return Task.FromResult(services);
        }
    }
}
