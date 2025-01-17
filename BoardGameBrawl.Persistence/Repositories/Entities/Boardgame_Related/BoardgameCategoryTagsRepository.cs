#nullable disable
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameCategoryTagsRepository : GenericRepository<BoardgameCategoryTag>, IBoardgameCategoryTagsRepository
    {
        public BoardgameCategoryTagsRepository(MainAppDBContext context) : base(context)
        {
        }

        public async Task<ICollection<BoardgameCategory>> GetBoardgameCategoriesByGameAsync(Guid boardgameId, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);

            var query = from categories in Context.BoardgameCategories
                        join boardgameCategories in Context.BoardgameCategoryTags
                        on categories.Id equals boardgameCategories.CategoryId
                        where boardgameCategories.BoardgameId == boardgameId
                        select categories;

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<ICollection<Boardgame>> GetBoardgamesByCategoryAsync(Guid categoryId, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(categoryId);

            var query = from boardgames in Context.Boardgames
                        join boardgameCategories in Context.BoardgameCategoryTags
                        on boardgames.Id equals boardgameCategories.BoardgameId
                        where boardgameCategories.CategoryId == categoryId
                        select boardgames;

            return await query.ToListAsync(cancellationToken);
        }
    }
}
