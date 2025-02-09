#nullable disable
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameMechanicTagsRepository : GenericRepository<BoardgameMechanicTag>, IBoardgameMechanicTagsRepository
    {
        private readonly IMapper _mapper;
        public BoardgameMechanicTagsRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        // refined methods //

        public async Task<bool> Exists(Guid boardgameId, Guid mechanicId,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);
            ArgumentNullException.ThrowIfNull(mechanicId);

            var entity = await Context.Set<BoardgameMechanicTag>().FindAsync(new[] { boardgameId, mechanicId }, cancellationToken);
            return entity != null;
        }


        // getter methods //

        public async Task<BoardgameMechanicTag> GetEntity(Guid boardgameId,
            Guid mechanicId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);
            ArgumentNullException.ThrowIfNull(mechanicId);

            return await _context.Set<BoardgameMechanicTag>().FindAsync(new[] { boardgameId, mechanicId }, cancellationToken);
        }

        public async Task<IList<BoardgameMechanicDTO>> GetBoardgameMechanicsByGameAsync(Guid boardgameId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);

            //var query = from mechanics in Context.BoardgameMechanics
            //            join boardgameMechanics in Context.BoardgameMechanicTags
            //            on mechanics.Id equals boardgameMechanics.MechanicId
            //            where boardgameMechanics.BoardgameId == boardgameId
            //            select mechanics;

            return await _context.BoardgameMechanics
                .Where(bm => bm.BoardgameMechanicTags!.Any(tag => tag.BoardgameId == boardgameId))
                .ProjectTo<BoardgameMechanicDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<NavBoardgameDTO>> GetBoardgamesByMechanicAsync(Guid mechanicId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(mechanicId);

            //var query = from boardgames in Context.Boardgames
            //            join boardgameMechanics in Context.BoardgameMechanicTags
            //            on boardgames.Id equals boardgameMechanics.BoardgameId
            //            where boardgameMechanics.MechanicId == mechanicId
            //            select boardgames;

            return await _context.Boardgames
                .Where(b => b.BoardgameMechanicTags!.Any(tag => tag.MechanicId == mechanicId))
                .ProjectTo<NavBoardgameDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<NavBoardgameDTO>> GetBatchOfBoardgamesByMechanicAsync(Guid mechanicId, int size, int skip = 0, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(mechanicId);

            if (size <= 0)
                throw new ArgumentException("Batch size must be greater than zero.", nameof(size));

            try
            {
                return await _context.Boardgames
                    .Where(b => b.BoardgameMechanicTags!.Any(bm => bm.MechanicId == mechanicId))
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
