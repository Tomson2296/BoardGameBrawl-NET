using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;

namespace BoardGameBrawl.Application.Contracts.Common
{
    public interface IUnitOfWork : IDisposable
    {
        // Player-related repositories
        IPlayerRepository PlayerRepository { get; }

        // Boardgame-related repositories
        
        IBoardgameRepository BoardgameRepository { get; }
        IBoardgameMechanicsRepository BoardgameMechanicsRepository { get; }
        IBoardgameMechanicTagsRepository BoardgameMechanicsTagsRepository { get; }
        IBoardgameCategoriesRepository BoardgameCategoryRepository { get; }
        IBoardgameCategoryTagsRepository BoardgameCategoryTagsRepository { get; }
        
        Task<bool> CommitChangesAsync();
    }
}
