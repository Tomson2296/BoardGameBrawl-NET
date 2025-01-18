using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameRepository : GenericRepository<Boardgame>, IBoardgameRepository
    {
        public BoardgameRepository(MainAppDBContext context) : base(context)
        {}

        
        // getter methods //

        public async Task<int> GetBGGIDAsync(Boardgame boardgame, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return await Task.FromResult(boardgame.BGGId);
        }

        public async Task<float> GetBGGWeightAsync(Boardgame boardgame, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return await Task.FromResult(boardgame.BGGWeight);
        }

        public async Task<string?> GetDescriptionAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return await Task.FromResult(boardgame.Description);
        }

        public async Task<byte[]?> GetImageAsync(Boardgame boardgame, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return await Task.FromResult(boardgame.Image);
        }

        public async Task<short> GetMaximumPlayingTimeAsync(Boardgame boardgame, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return await Task.FromResult(boardgame.MaximumPlayingTime);
        }

        public async Task<byte> GetMaxPlayersAsync(Boardgame boardgame, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return await Task.FromResult(boardgame.MaxPlayers);
        }

        public async Task<short> GetMinimumPlayingTimeAsync(Boardgame boardgame, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return await Task.FromResult(boardgame.MinimumPlayingTime);
        }

        public async Task<byte> GetMinPlayersAsync(Boardgame boardgame, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return await Task.FromResult(boardgame.MinPlayers);
        }

        public async Task<string?> GetNameAsync(Boardgame boardgame, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return await Task.FromResult(boardgame.Name);
        }

        public async Task<short> GetPlayingTimeAsync(Boardgame boardgame, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return await Task.FromResult(boardgame.PlayingTime);
        }

        public async Task<short> GetYearPublishedAsync(Boardgame boardgame, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);

            return await Task.FromResult(boardgame.YearPublished);
        }

        // setter methods //

        public Task SetBGGWeight(Boardgame boardgame, float weight, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgame);
            ArgumentNullException.ThrowIfNull(weight);

            boardgame.BGGWeight = weight;
            return Task.CompletedTask;
        }
    }
}
