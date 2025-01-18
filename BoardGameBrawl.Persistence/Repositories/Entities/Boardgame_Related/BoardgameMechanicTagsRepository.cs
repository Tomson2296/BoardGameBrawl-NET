#nullable disable
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameMechanicTagsRepository : GenericRepository<BoardgameMechanicTag>, IBoardgameMechanicTagsRepository
    {
        public BoardgameMechanicTagsRepository(MainAppDBContext context) : base(context)
        { }

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

        public async Task<ICollection<BoardgameMechanic>> GetBoardgameMechanicsByGameAsync(Guid boardgameId, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);

            var query = from mechanics in Context.BoardgameMechanics
                        join boardgameMechanics in Context.BoardgameMechanicTags
                        on mechanics.Id equals boardgameMechanics.MechanicId
                        where boardgameMechanics.BoardgameId == boardgameId
                        select mechanics;

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<ICollection<Boardgame>> GetBoardgamesByMechanicAsync(Guid mechanicId, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(mechanicId);

            var query = from boardgames in Context.Boardgames
                        join boardgameMechanics in Context.BoardgameMechanicTags
                        on boardgames.Id equals boardgameMechanics.BoardgameId
                        where boardgameMechanics.MechanicId == mechanicId
                        select boardgames;

            return await query.ToListAsync(cancellationToken);
        }
    }
}
