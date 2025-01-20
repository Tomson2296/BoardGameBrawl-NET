﻿using BoardGameBrawl.Application.Contracts.Common;
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

        Task<ICollection<Boardgame>> GetBoardgamesByMechanicAsync(Guid mechanicId, 
            CancellationToken cancellationToken = default);

        Task<ICollection<BoardgameMechanic>> GetBoardgameMechanicsByGameAsync(Guid boardgameId, 
            CancellationToken cancellationToken = default);
    }
}
