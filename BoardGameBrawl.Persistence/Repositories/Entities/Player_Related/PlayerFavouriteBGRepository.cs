using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Player_Related
{
    public class PlayerFavouriteBGRepository : GenericRepository<PlayerFavouriteBG>, IPlayerFavouriteBGRepository
    {
        private readonly IMapper _mapper;
        public PlayerFavouriteBGRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        // custom methods //

        public async Task<bool> Exists(Guid playerId, Guid boardgameId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var entity = await _context.PlayerFavouriteBGs.FindAsync(playerId, boardgameId, cancellationToken);
            return entity != null;
        }
       
        // getter methods //

        public async Task<PlayerFavouriteBG> GetPlayerFavouriteBGAsync(Guid playerId, Guid boardgameId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);
            ArgumentNullException.ThrowIfNull(boardgameId);

            var playerFavourite = await _context.PlayerFavouriteBGs.
                FirstOrDefaultAsync(e => e.PlayerId == playerId && e.BoardgameId == boardgameId, cancellationToken);

            if (playerFavourite != null)
                return playerFavourite;
            else
                throw new ApplicationException("Entity has not been found");
        }

        public async Task<IList<PlayerFavouriteBGDTO>> GetAllPlayerFavouriteBGsAsync(Guid playerId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);

            bool isAnyPlayerFavouriteExists = await _context.PlayerFavouriteBGs.AnyAsync(e => e.PlayerId == playerId, cancellationToken);

            if (isAnyPlayerFavouriteExists == false)
            {
                throw new ArgumentException("Entity has not been found");
            }
            else
            {
                return await _context.PlayerFavouriteBGs
                        .Where(e => e.PlayerId == playerId)
                        .ProjectTo<PlayerFavouriteBGDTO>(_mapper.ConfigurationProvider)
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);
            }
        }

        public async Task<IList<PlayerFavouriteBGDTO>> GetAllPlayersFavouringBGAsync(Guid boardgameId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);

            bool isAnyBoardgameFavouriteExists = await _context.PlayerFavouriteBGs.AnyAsync(e => e.BoardgameId == boardgameId, cancellationToken);

            if (isAnyBoardgameFavouriteExists == false)
            {
                throw new ArgumentException("Entity has not been found");
            }
            else
            {
                return await _context.PlayerFavouriteBGs
                        .Where(e => e.BoardgameId == boardgameId)
                        .ProjectTo<PlayerFavouriteBGDTO>(_mapper.ConfigurationProvider)
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);
            }
        }

    }
}
