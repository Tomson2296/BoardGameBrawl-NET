using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Contracts.Entities.Player_Related
{
    public interface IPlayerFavouriteBGRepository : IGenericRepository<PlayerFavouriteBG>, IAuditableRepository<PlayerFavouriteBG>
    {
        // custom methods //

        Task<bool> Exists(Guid playerId,
           Guid boardgameId, CancellationToken cancellationToken = default);


        // getter methods //

        Task<PlayerFavouriteBG> GetPlayerFavouriteBGAsync(Guid playerId,
            Guid boardgameId,
            CancellationToken cancellationToken = default);

        Task<IList<PlayerFavouriteBGDTO>> GetAllPlayerFavouriteBGsAsync(Guid playerId,
            CancellationToken cancellationToken = default);

        Task<IList<PlayerFavouriteBGDTO>> GetAllPlayersFavouringBGAsync(Guid boardgameId,
            CancellationToken cancellationToken = default);
    }
}
