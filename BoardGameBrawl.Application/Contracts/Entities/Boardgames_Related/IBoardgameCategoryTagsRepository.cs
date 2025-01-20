
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related
{
    public interface IBoardgameCategoryTagsRepository : IGenericRepository<BoardgameCategoryTag>
    {
        // refined methods //
        
        Task<bool> Exists(Guid boardgameId,
           Guid categoryId,
           CancellationToken cancellationToken = default);


        // getter methods //

        Task<BoardgameCategoryTag> GetEntity(Guid boardgameId,
           Guid categoryId,
           CancellationToken cancellationToken = default);

        Task<ICollection<Boardgame>> GetBoardgamesByCategoryAsync(Guid categoryId,
            CancellationToken cancellationToken = default);

        Task<ICollection<BoardgameCategory>> GetBoardgameCategoriesByGameAsync(Guid boardgameId,
            CancellationToken cancellationToken = default);
    }
}
