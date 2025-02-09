using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related
{
    public interface IBoardgameMechanicTagsRepository : IGenericRepository<BoardgameMechanicTag>
    {
        // refined methods //
        Task<bool> Exists(Guid boardgameId,
           Guid mechanicId,
           CancellationToken cancellationToken = default);

        
        // getter methods //

        Task<BoardgameMechanicTag> GetEntity(Guid boardgameId,
           Guid mechanicId,
           CancellationToken cancellationToken = default);

        Task<IList<BoardgameMechanicDTO>> GetBoardgameMechanicsByGameAsync(Guid boardgameId,
           CancellationToken cancellationToken = default);


        Task<IList<NavBoardgameDTO>> GetBoardgamesByMechanicAsync(Guid mechanicId, 
            CancellationToken cancellationToken = default);

        Task<IList<NavBoardgameDTO>> GetBatchOfBoardgamesByMechanicAsync(Guid mechanicId,
           int size, int skip = 0, CancellationToken cancellationToken = default);
    }
}
