using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameModeratorsRepository : GenericRepository<BoardgameModerator>, IBoardgameModeratorsRepository
    {
        private readonly IMapper mapper;

        public BoardgameModeratorsRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<BoardgameModerator?> GetBoardgameModeratorAsync(Guid moderatorId, 
            Guid boardgameId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(moderatorId);
            ArgumentNullException.ThrowIfNull(boardgameId);

            var moderatorInDB = await Context.BoardgameModerators.
                FirstOrDefaultAsync(e => e.ModeratorId == moderatorId && e.BoardgameId == boardgameId, cancellationToken);

            if (moderatorInDB != null)
                return moderatorInDB;
            else
                throw new ApplicationException("Entity has not been found");
        }

        public async Task<IList<NavPlayerDTO>> GetAllModeratorsForBoardgameAsync(Guid boardgameId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);

            return await _context.Players
                .Where(p => p.BoardgameModerators!.Any(par => par.BoardgameId == boardgameId))
                .ProjectTo<NavPlayerDTO>(mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<NavBoardgameDTO>> GetAllPlayerModerationsAsync(Guid moderatorId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(moderatorId);

            return await _context.Boardgames
                .Where(p => p.BoardgameModerators!.Any(par => par.ModeratorId == moderatorId))
                .ProjectTo<NavBoardgameDTO>(mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> Exists(Guid moderatorId, Guid boardgameId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(moderatorId);
            ArgumentNullException.ThrowIfNull(boardgameId);

            var exists = await _context.BoardgameModerators.FindAsync(boardgameId, moderatorId, cancellationToken);
            return exists != null;
        }
    }
}
