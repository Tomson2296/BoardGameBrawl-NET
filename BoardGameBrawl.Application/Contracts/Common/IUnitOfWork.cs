using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.Contracts.Entities.Group_Related;
using BoardGameBrawl.Application.Contracts.Entities.Match_Related;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;

namespace BoardGameBrawl.Application.Contracts.Common
{
    public interface IUnitOfWork : IDisposable
    {
        // Player-related repositories
        IPlayerRepository PlayerRepository { get; }
        IPlayerPreferenceRepository PlayerPreferenceRepository { get; }
        IPlayerFriendRepository PlayerFriendRepository { get; }
        IPlayerCollectionRepository PlayerCollectionRepository { get; }
        IPlayerFavouriteBGRepository PlayerFavouriteBGRepository { get; }

        IPlayerScheduleRepository PlayerScheduleRepository { get; }


        // Boardgame-related repositories
        IBoardgameRepository BoardgameRepository { get; }
        IBoardgameMechanicsRepository BoardgameMechanicsRepository { get; }
        IBoardgameMechanicTagsRepository BoardgameMechanicsTagsRepository { get; }
        IBoardgameCategoriesRepository BoardgameCategoriesRepository { get; }
        IBoardgameCategoryTagsRepository BoardgameCategoryTagsRepository { get; }
        IBoardgameDomainsRepository BoardgameDomainsRepository { get; }
        IBoardgameDomainTagsRepository BoardgameDomainTagsRepository { get; }
        IBoardgameModeratorsRepository BoardgameModeratorsRepository { get; }


        // Group-related repositories
        IGroupRepository GroupRepository { get; }
        IGroupParticipantRepository GroupParticipantRepository { get; }


        // Match-related repositories 
        IMatchRuleRepository MatchRuleRepository { get; }


        Task CommitChangesAsync();
    }
}
