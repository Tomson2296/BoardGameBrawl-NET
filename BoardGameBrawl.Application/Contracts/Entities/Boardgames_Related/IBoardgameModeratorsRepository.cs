using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related
{
    public interface IBoardgameModeratorsRepository : IGenericRepository<BoardgameModerator>, IAuditableRepository<BoardgameModerator>
    {
        // custom methods // 

        Task<bool> Exists(Guid moderatorId, Guid boardgameId, CancellationToken cancellationToken = default);


        // getter methods // 


        Task<BoardgameModerator?> GetBoardgameModeratorAsync(Guid moderatorId,
           Guid boardgameId, CancellationToken cancellationToken = default);

        Task<IList<NavBoardgameDTO>> GetAllPlayerModerationsAsync(Guid moderatorId,
          CancellationToken cancellationToken = default);

        Task<IList<NavPlayerDTO>> GetAllModeratorsForBoardgameAsync(Guid boardgameId,
            CancellationToken cancellationToken = default);
    }
}
