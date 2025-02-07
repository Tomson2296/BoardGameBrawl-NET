using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related
{
    public interface IBoardgameRepository : IGenericRepository<Boardgame>, IAuditableRepository<Boardgame>
    {
        // custom refined methods //
        
        Task<bool> Exists(int bggid, CancellationToken cancellationToken = default);


        // basic fields getter methods //

        Task<string?> GetNameAsync(Boardgame boardgame,
           CancellationToken cancellationToken = default);

        Task<int> GetBGGIDAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default);

        Task<short> GetYearPublishedAsync(Boardgame boardgame,
            CancellationToken cancellationToken = default);

        Task<byte> GetMinPlayersAsync(Boardgame boardgame,
           CancellationToken cancellationToken = default);

        Task<byte> GetMaxPlayersAsync(Boardgame boardgame,
           CancellationToken cancellationToken = default);

        Task<short> GetPlayingTimeAsync(Boardgame boardgame,
           CancellationToken cancellationToken = default);

        Task<short> GetMinimumPlayingTimeAsync(Boardgame boardgame,
          CancellationToken cancellationToken = default);

        Task<short> GetMaximumPlayingTimeAsync(Boardgame boardgame,
          CancellationToken cancellationToken = default);

        Task<float> GetBGGWeightAsync(Boardgame boardgame,
          CancellationToken cancellationToken = default);

        Task<byte[]?> GetImageAsync(Boardgame boardgame,
         CancellationToken cancellationToken = default);

        Task<string?> GetDescriptionAsync(Boardgame boardgame,
         CancellationToken cancellationToken = default);

        
        // basic field setter methods //
        // weight may be updated once for a while //
        
        Task SetBGGWeight(Boardgame boardgame,
         float weight,
         CancellationToken cancellationToken = default);
    }
}
