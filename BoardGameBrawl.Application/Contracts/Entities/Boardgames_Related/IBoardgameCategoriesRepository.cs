using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related
{
    public interface IBoardgameCategoriesRepository : IGenericRepository<BoardgameCategory>, IAuditableRepository<BoardgameCategory>
    {
        // refined methods //
        
        Task<bool> Exists(BoardgameCategory boardgameCategory,
            CancellationToken cancellationToken = default);
        
        // basic fields getter methods //

        Task<Guid> GetBoardgameCategoryIdAsync(string? categoryName,
            CancellationToken cancellationToken = default);

        Task<BoardgameCategory?> GetBoardgameCategoryByNameAsync(string? categoryName,
            CancellationToken cancellationToken = default);
        
        Task<string?> GetCategoryNameAsync(BoardgameCategory category,
           CancellationToken cancellationToken = default);

        // basic fields setter methods //

        Task SetCategoryNameAsync(BoardgameCategory category,
            string? categoryName, CancellationToken cancellationToken = default);
    }
}
