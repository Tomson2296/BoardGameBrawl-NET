﻿using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.Exceptions;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameRepository : GenericRepository<Boardgame>, IBoardgameRepository
    {
        public BoardgameRepository(MainAppDBContext context) : base(context)
        { }


        // custom BoardgameRepository methods //

        public async Task<Boardgame?> GetEntityByBGGId(int id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var boardgame = await Context.Boardgames.FirstOrDefaultAsync(b => b.BGGId == id, cancellationToken);
            return boardgame;
        }

        public async Task<bool> Exists(int bggid, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await Context.Boardgames.AnyAsync(b => b.BGGId == bggid, cancellationToken);
        }


        // getter methods //

        public Task<int> GetBGGIDAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return Task.FromResult(boardgame.BGGId);
        }

        public Task<float> GetBGGWeightAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return Task.FromResult(boardgame.AverageBGGWeight);
        }

        public Task<string?> GetDescriptionAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return Task.FromResult(boardgame.Description);
        }
        public Task<byte[]?> GetImageAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return Task.FromResult(boardgame.Image);
        }

        public Task<short> GetMaximumPlayingTimeAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return Task.FromResult(boardgame.MaximumPlayingTime);
        }

        public Task<byte> GetMaxPlayersAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return Task.FromResult(boardgame.MaxPlayers);
        }

        public Task<short> GetMinimumPlayingTimeAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return Task.FromResult(boardgame.MinimumPlayingTime);
        }

        public Task<byte> GetMinPlayersAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return Task.FromResult(boardgame.MinPlayers);
        }

        public Task<string?> GetNameAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return Task.FromResult(boardgame.Name);
        }

        public Task<short> GetPlayingTimeAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return Task.FromResult(boardgame.PlayingTime);
        }

        public Task<short> GetYearPublishedAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return Task.FromResult(boardgame.YearPublished);
        }

        // setter methods //

        public Task SetBGGWeight(Boardgame boardgame, float weight,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);
            ArgumentNullException.ThrowIfNull(weight);

            boardgame.AverageBGGWeight = weight;
            return Task.CompletedTask;
        }
    }
}
