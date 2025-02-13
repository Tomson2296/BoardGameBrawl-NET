using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.Contracts.Entities.Group_Related;
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.Contracts.Entities.Match_Related;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.Repositories.Common;
using BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Entities.Group_Related;
using BoardGameBrawl.Persistence.Repositories.Entities.Match_Related;
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
            services.AddScoped<IPlayerPreferenceRepository, PlayerPreferenceRepository>();
            services.AddScoped<IPlayerFriendRepository, PlayerFriendRepository>();
            services.AddScoped<IPlayerCollectionRepository, PlayerCollectionRepository>();
            services.AddScoped<IPlayerFavouriteBGRepository, PlayerFavouriteBGRepository>();
            services.AddScoped<IPlayerScheduleRepository, PlayerScheduleRepository>();

            // Register Boardgames-Related repositories

            services.AddScoped<IBoardgameRepository, BoardgameRepository>();
            services.AddScoped<IBoardgameDomainsRepository, BoardgameDomainsRepository>();
            services.AddScoped<IBoardgameDomainTagsRepository, BoardgameDomainTagsRepository>();
            services.AddScoped<IBoardgameCategoriesRepository, BoardgameCategoriesRepository>();
            services.AddScoped<IBoardgameCategoryTagsRepository, BoardgameCategoryTagsRepository>();
            services.AddScoped<IBoardgameMechanicsRepository, BoardgameMechanicsRepository>();
            services.AddScoped<IBoardgameMechanicTagsRepository, BoardgameMechanicTagsRepository>();
            services.AddScoped<IBoardgameModeratorsRepository, BoardgameModeratorsRepository>();

            // Register Group-Related repositories

            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupParticipantRepository, GroupParticipantRepository>();

            // Register Match-related repositories

            services.AddScoped<IMatchRuleRepository, MatchRuleRepository>();

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

            // Register ApplicationUserQuery and ApplicationUserCommand Service
            services.AddScoped<IApplicationUserQueryService, ApplicationUserQueryService>();
            services.AddScoped<IApplicationUserCommandService, ApplicationUserCommandService>();

            return Task.FromResult(services);
        }
    }
}
