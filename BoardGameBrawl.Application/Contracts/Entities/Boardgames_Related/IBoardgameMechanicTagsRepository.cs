using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related
{
    public interface IBoardgameMechanicTagsRepository : IGenericRepository<BoardgameMechanicTag>
    {
        public Task<ICollection<Boardgame>> GetBoardgamesByMechanicAsync(Guid mechanicId, 
            CancellationToken cancellationToken = default);

        public Task<ICollection<BoardgameMechanic>> GetBoardgameMechanicsByGameAsync(Guid boardgameId, 
            CancellationToken cancellationToken = default);
    }
}
