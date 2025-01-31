using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameCategoriesRepository : GenericRepository<BoardgameCategory>, IBoardgameCategoriesRepository
    {
        public BoardgameCategoriesRepository(MainAppDBContext context) : base(context)
        { }

        // refined methods //

        public async Task<bool> Exists(BoardgameCategory boardgameCategory,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameCategory);

            // Check ChangeTracker if entity exists in waiting list to be added

            bool isTracked = Context.ChangeTracker
            .Entries<BoardgameCategory>()
            .Any(e => e.Entity.Category == boardgameCategory.Category);

            if (isTracked)
            {
                return true;
            }
            else
            {
                var categoryObj = await Context.BoardgameCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Category == boardgameCategory.Category, cancellationToken);

                if (categoryObj != null)
                    return true;
                else
                    return false;
            }
        }

        // getter methods //

        public async Task<BoardgameCategory?> GetBoardgameCategoryByNameAsync(string? categoryName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentException("Category name cannot be null or whitespace.", nameof(categoryName));
            }

            var categoryObj = await Context.BoardgameCategories
                .FirstOrDefaultAsync(e => e.Category == categoryName, cancellationToken);

            if (categoryObj != null)
                return categoryObj;
            else
                throw new ApplicationException("Entity has not been found");
        }

        public async Task<Guid> GetBoardgameCategoryIdAsync(string? categoryName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentException("Category name cannot be null or whitespace.", nameof(categoryName));
            }

            // Check ChangeTracker if entity exists in waiting list to be added
            // If found - get an ID of that entity

            bool isTracked = Context.ChangeTracker
           .Entries<BoardgameCategory>()
           .Any(e => e.Entity.Category == categoryName);

            if (isTracked)
            {
                var entity = Context.ChangeTracker
                               .Entries<BoardgameCategory>()
                               .FirstOrDefault(e => e.Entity.Category == categoryName);
                return entity!.Entity.Id;
            }

            var categoryObj = await Context.BoardgameCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Category == categoryName, cancellationToken);

            if (categoryObj != null)
                return categoryObj.Id;
            else
                throw new ApplicationException("Entity has not been found");
        }

        public Task<string?> GetCategoryNameAsync(BoardgameCategory category,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(category);

            return Task.FromResult(category.Category);
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
