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
        // custom IPlayerFavouriteBGRepo methods //
    }
}
