
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
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

        Task<IList<BoardgameCategoryDTO>> GetBoardgameCategoriesByGameAsync(Guid boardgameId,
            CancellationToken cancellationToken = default);

        
        Task<IList<NavBoardgameDTO>> GetBoardgamesByCategoryAsync(Guid categoryId,
            CancellationToken cancellationToken = default);

        Task<IList<NavBoardgameDTO>> GetBatchOfBoardgamesByCategoryAsync(Guid categoryId,
            int size, int skip = 0, CancellationToken cancellationToken = default);
    }
}
