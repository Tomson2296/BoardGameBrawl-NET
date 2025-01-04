using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;

namespace BoardGameBrawl.Application.Contracts.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository PlayerRepository { get; }
        IBoardgameRepository BoardgameRepository { get; }
        
        IBoardgameMechanicsRepository BoardgameMechanicsRepository { get; }
        IBoardgameMechanicsTagsRepository BoardgameMechanicsTagsRepository { get; }
        
        IBoardgameCategoryRepository BoardgameCategoryRepository { get; }
        IBoardgameCategoryTagsRepository BoardgameCategoryTagsRepository { get; }
        
        
        Task<bool> CommitChangesAsync();
    }
}
