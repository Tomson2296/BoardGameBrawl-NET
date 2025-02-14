using AutoMapper;
using AutoMapper.Configuration.Annotations;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Preference_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Preference_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Player_Related
{
    public class PlayerPreferenceRepository : GenericRepository<PlayerPreference>, IPlayerPreferenceRepository
    {
        private readonly IMapper _mapper;

        public PlayerPreferenceRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        // refined mthods //

        public async Task<bool> Exists(Guid playerId,
            Guid boardgameId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);
            ArgumentNullException.ThrowIfNull(boardgameId);

            var entity = await _context.PlayerPreferences.FindAsync( playerId, boardgameId, cancellationToken);
            return entity != null;
        }


        // getter methods //

        public async Task<PlayerPreferenceDTO> GetPlayerPreferenceAsync(Guid playerId,
           Guid boardgameId,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);
            ArgumentNullException.ThrowIfNull(boardgameId);

            var playerPreference = await _context.PlayerPreferences
                .FirstOrDefaultAsync(e => e.PlayerId == playerId && e.BoardgameId == boardgameId, cancellationToken);

            if (playerPreference != null)
                return _mapper.Map<PlayerPreferenceDTO>(_mapper.ConfigurationProvider);
            else
                throw new ApplicationException("Entity has not been found");
        }

        public async Task<IList<PlayerPreferenceDTO>> GetAllPlayerPreferencesAsync(Guid playerId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);

            bool isPlayerPreferenceExists = await _context.PlayerPreferences.AnyAsync(e => e.PlayerId == playerId, cancellationToken);

            if (isPlayerPreferenceExists == false)
            {
                throw new ArgumentException("Entity has not been found");
            }
            else
            {
                return await _context.PlayerPreferences
                        .Where(e => e.PlayerId == playerId)
                        .ProjectTo<PlayerPreferenceDTO>(_mapper.ConfigurationProvider)
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);
            }
        }

        public async Task<IList<PlayerPreferenceDTO>> GetAllBoardgamePrefencesChosenByPlayersAsync(Guid boardgameId, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);

            bool isBoardgamePreferenceExists = await _context.PlayerPreferences.AnyAsync(e => e.BoardgameId == boardgameId, cancellationToken);

            if (isBoardgamePreferenceExists == false)
            {
                throw new ArgumentException("Entity has not been found");
            }
            else
            {
                return await _context.PlayerPreferences
                        .Where(e => e.BoardgameId == boardgameId)
                        .ProjectTo<PlayerPreferenceDTO>(_mapper.ConfigurationProvider)
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);
            }
        }

        // setter methods //

        public async Task SetPlayerPreferenceAboutBoardgameAsync(Guid playerId,
            Guid boardgameId, byte rating, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);
            ArgumentNullException.ThrowIfNull(boardgameId);
            ArgumentNullException.ThrowIfNull(rating);

            var playerPreference = await _context.PlayerPreferences.FirstOrDefaultAsync(e => e.PlayerId == playerId && e.BoardgameId == boardgameId, cancellationToken);

            if (playerPreference != null)
            {
                playerPreference.Rating = rating;
            }
            else
            {
                throw new ApplicationException("Entity has not been found");
            }
        }

        public async Task<IList<CompositePlayerBoardgamePreferencesDTO>> GetCompositePlayerBoardgamePreferences(Guid playerId, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);

            //var playerPreferences = await _context.PlayerPreferences
            //            .Where(e => e.PlayerId == playerId)
            //            .AsNoTracking()
            //            .ToListAsync(cancellationToken);

            //var listOFBoardgames = await _context.Boardgames
            //            .Where(b => b.PlayerPreferences!.Any(pf => pf.PlayerId == playerId))
            //            .AsNoTracking()
            //            .ToListAsync(cancellationToken);

            var compositeList = await (from preferences in _context.PlayerPreferences
                                 join boardgames in _context.Boardgames
                                 on preferences.BoardgameId equals boardgames.Id
                                 where preferences.PlayerId == playerId
                                 select new CompositePlayerBoardgamePreferences
                                 {
                                     PlayerPreference = preferences,
                                     Boardgame = boardgames
                                 }).ToListAsync(cancellationToken);

            return _mapper.Map<IList<CompositePlayerBoardgamePreferencesDTO>>(compositeList);
        }

        public async Task<IList<CompositeBoardgamePreferencesByPlayersDTO>> GetBoardgamePreferencesByPlayers(Guid boardgameId, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);

            var compositeList = await (from preferences in _context.PlayerPreferences
                                 join players in _context.Players
                                 on preferences.PlayerId equals players.Id
                                 where preferences.BoardgameId == boardgameId
                                 select new CompositeBoardgamePreferencesByPlayers
                                 {
                                     PlayerPreference = preferences,
                                     Player = players
                                 }).ToListAsync(cancellationToken);

            return _mapper.Map<IList<CompositeBoardgamePreferencesByPlayersDTO>>(compositeList);
        }
    }
}