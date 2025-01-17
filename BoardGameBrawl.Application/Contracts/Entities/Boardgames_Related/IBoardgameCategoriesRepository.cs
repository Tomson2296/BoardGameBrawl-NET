using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related
{
    public interface IBoardgameCategoriesRepository : IGenericRepository<BoardgameCategory>, IAuditableRepository<BoardgameCategory>
    {
        // basic fields getter methods //
        
        Task<string?> GetCategoryNameAsync(BoardgameCategory category,
           CancellationToken cancellationToken = default);

        // basic fields setter methods //

        Task SetCategoryNameAsync(BoardgameCategory category,
            string? categoryName, CancellationToken cancellationToken = default);
    }
}
