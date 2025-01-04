using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameMechanicRepository : GenericRepository<BoardgameMechanic>, IBoardgameMechanicsRepository
    {
        public BoardgameMechanicRepository(MainAppDBContext context) : base(context)
        { }
    }
}
