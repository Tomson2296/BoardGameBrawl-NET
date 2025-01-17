using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameCategoriesRepository : GenericRepository<BoardgameCategory>, IBoardgameCategoriesRepository
    {
        public BoardgameCategoriesRepository(MainAppDBContext context) : base(context)
        { }
        
        // getter methods //

        public async Task<string?> GetCategoryNameAsync(BoardgameCategory category, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(category);

            return await Task.FromResult(category.Category);
        }

        // setter methods //

        public Task SetCategoryNameAsync(BoardgameCategory category, 
            string? categoryName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(category);

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentException("Category name cannot be null or whitespace.", nameof(categoryName));
            }

            category.Category = categoryName;
            return Task.CompletedTask;
        }
    }
}
