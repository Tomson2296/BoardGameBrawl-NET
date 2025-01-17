using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related
{
    public interface IBoardgameRepository : IGenericRepository<Boardgame>
    {
        // basic fields getter methods //

        public Task<string?> GetNameAsync(Boardgame boardgame,
           CancellationToken cancellationToken = default);

        public Task<int> GetBGGIDAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default);

        public Task<short> GetYearPublishedAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default);

        public Task<byte> GetMinPlayersAsync(Boardgame boardgame,
           CancellationToken cancellationToken = default);

        public Task<byte> GetMaxPlayersAsync(Boardgame boardgame,
           CancellationToken cancellationToken = default);

        public Task<short> GetPlayingTimeAsync(Boardgame boardgame,
           CancellationToken cancellationToken = default);

        public Task<short> GetMinimumPlayingTimeAsync(Boardgame boardgame,
          CancellationToken cancellationToken = default);

        public Task<short> GetMaximumPlayingTimeAsync(Boardgame boardgame,
          CancellationToken cancellationToken = default);

        public Task<float> GetBGGWeightAsync(Boardgame boardgame,
          CancellationToken cancellationToken = default);

        public Task<byte[]?> GetImageAsync(Boardgame boardgame,
         CancellationToken cancellationToken = default);

        public Task<string?> GetDescriptionAsync(Boardgame boardgame,
         CancellationToken cancellationToken = default);

        
        // basic field setter methods //
        // weight may be updated once for a while //
        
        public Task SetBGGWeight(Boardgame boardgame,
         float weight,
         CancellationToken cancellationToken = default);
    }
}
