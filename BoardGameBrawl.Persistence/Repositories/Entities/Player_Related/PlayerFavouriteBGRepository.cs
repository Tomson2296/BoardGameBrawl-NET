using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Player_Related
{
    public class PlayerFavouriteBGRepository : GenericRepository<PlayerFavouriteBG>, IPlayerFavouriteBGRepository
    {
        public PlayerFavouriteBGRepository(MainAppDBContext context) : base(context)
        {

        }
    }
}
