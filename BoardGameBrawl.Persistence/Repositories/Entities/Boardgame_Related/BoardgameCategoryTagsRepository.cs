#nullable disable
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameCategoryTagsRepository : GenericRepository<BoardgameCategoryTag>, IBoardgameCategoryTagsRepository
    {
        private readonly IMapper _mapper;
        public BoardgameCategoryTagsRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        // refined methods // 

        public async Task<bool> Exists(Guid boardgameId, Guid categoryId,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);
            ArgumentNullException.ThrowIfNull(categoryId);

            var entity = await Context.Set<BoardgameCategoryTag>().FindAsync(new[] { boardgameId, categoryId }, cancellationToken);
            return entity != null;
        }

        // getter methods //

        public async Task<BoardgameCategoryTag> GetEntity(Guid boardgameId,
            Guid categoryId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);
            ArgumentNullException.ThrowIfNull(categoryId);

            return await _context.Set<BoardgameCategoryTag>().FindAsync(new[] { boardgameId, categoryId }, cancellationToken);
        }

        public async Task<IList<BoardgameCategoryDTO>> GetBoardgameCategoriesByGameAsync(Guid boardgameId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);

            //var query = from categories in Context.BoardgameCategories
            //            join boardgameCategories in Context.BoardgameCategoryTags
            //            on categories.Id equals boardgameCategories.CategoryId
            //            where boardgameCategories.BoardgameId == boardgameId
            //            select categories;

            return await _context.BoardgameCategories
                .Where(bc => bc.BoardgameCategoryTags!.Any(tag => tag.BoardgameId == boardgameId))
                .ProjectTo<BoardgameCategoryDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<NavBoardgameDTO>> GetBoardgamesByCategoryAsync(Guid categoryId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(categoryId);

            //var query = from boardgames in Context.Boardgames
            //            join boardgameCategories in Context.BoardgameCategoryTags
            //            on boardgames.Id equals boardgameCategories.BoardgameId
            //            where boardgameCategories.CategoryId == categoryId
            //            select boardgames;

            return await _context.Boardgames
                .Where(b => b.BoardgameCategoryTags!.Any(tag => tag.CategoryId == categoryId))
                .ProjectTo<NavBoardgameDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

        }

        public async Task<IList<NavBoardgameDTO>> GetBatchOfBoardgamesByCategoryAsync(Guid categoryId, int size, int skip = 0, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(categoryId);

            if (size <= 0)
                throw new ArgumentException("Batch size must be greater than zero.", nameof(size));

            try
            {
                return await _context.Boardgames
                    .Where(b => b.BoardgameCategoryTags!.Any(bc => bc.CategoryId == categoryId))
                    .OrderBy(b => b.Name)
                    .ProjectTo<NavBoardgameDTO>(_mapper.ConfigurationProvider)
                    .Skip(skip)
                    .Take(size)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving a batch of entities.", ex);
            }
        }
    }
}
