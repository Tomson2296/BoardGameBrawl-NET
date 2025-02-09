﻿using AutoMapper;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Player_Related
{
    public class PlayerPreferenceRepository : GenericRepository<PlayerRreference>, IPlayerPreferenceRepository
    {

        public PlayerPreferenceRepository(MainAppDBContext context) : base(context)
        {
        }

        // refined mthods //

        public async Task<bool> Exists(Guid playerId,
            Guid boardgameId,
            CancellationToken cancellationToken = default)
        {
            var entity = await _context.PlayerRreferences.FindAsync(new[] { playerId, boardgameId }, cancellationToken);
            return entity != null;
        }


        // getter methods //

        public async Task<PlayerRreference> GetPlayerPreferenceByBoardgameIdAsync(Guid playerId,
           Guid boardgameId,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);
            ArgumentNullException.ThrowIfNull(boardgameId);

            var playerPreference = await _context.PlayerRreferences.FirstOrDefaultAsync(e => e.PlayerId == playerId && e.BoardgameId == boardgameId, cancellationToken);

            if (playerPreference != null)
                return playerPreference;
            else
                throw new ApplicationException("Entity has not been found");
        }

        public async Task<IDictionary<Guid, byte>> GetAllPlayerPreferencesAsync(Guid playerId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);

            bool isPlayerPreferenceExists = await _context.PlayerRreferences.AnyAsync(e => e.PlayerId == playerId, cancellationToken);

            if (isPlayerPreferenceExists == false)
            {
                throw new ArgumentException("Entity has not been found");
            }
            else
            {
                var playerPreferences = await _context.PlayerRreferences
                        .Where(e => e.PlayerId == playerId)
                        .AsNoTracking()
                        .ToDictionaryAsync(e => e.BoardgameId, e => e.Rating, cancellationToken);

                return playerPreferences;
            }
        }

        public async Task<IDictionary<Guid, byte>> GetAllBoardgamePrefencesAsync(Guid boardgameId, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);

            bool isBoardgamePreferenceExists = await _context.PlayerRreferences.AnyAsync(e => e.BoardgameId == boardgameId, cancellationToken);

            if (isBoardgamePreferenceExists == false)
            {
                throw new ArgumentException("Entity has not been found");
            }
            else
            {
                var boardgamePreferences = await _context.PlayerRreferences
                        .Where(e => e.BoardgameId == boardgameId)
                        .AsNoTracking()
                        .ToDictionaryAsync(e => e.PlayerId, e => e.Rating, cancellationToken);

                return boardgamePreferences;
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

            var playerPreference = await _context.PlayerRreferences.FirstOrDefaultAsync(e => e.PlayerId == playerId && e.BoardgameId == boardgameId, cancellationToken);

            if (playerPreference != null)
            {
                playerPreference.Rating = rating;
            }
            else
            {
                throw new ApplicationException("Entity has not been found");
            }
        }
    }
}