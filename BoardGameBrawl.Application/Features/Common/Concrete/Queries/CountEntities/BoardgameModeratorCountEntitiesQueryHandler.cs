using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Features.Common.Queries.CountEntities;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Concrete.Queries.CountEntities
{
    public class BoardgameModeratorCountEntitiesQueryHandler : CountEntitiesQueryHandler<CountEntitiesQuery, BoardgameModerator>
    {
        public BoardgameModeratorCountEntitiesQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IGenericRepository<BoardgameModerator> GetRepository(IUnitOfWork unitOfWork)
        {
            return unitOfWork.BoardgameModeratorsRepository;
        }
    }
}
