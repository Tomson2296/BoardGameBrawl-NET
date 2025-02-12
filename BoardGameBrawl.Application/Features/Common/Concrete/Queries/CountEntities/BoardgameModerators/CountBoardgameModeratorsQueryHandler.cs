using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Features.Common.Queries.CountEntities;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Concrete.Queries.CountEntities.BoardgameModerators
{
    public class CountBoardgameModeratorsQueryHandler : CountEntitiesQueryHandler<ConcreteCountEntitiesQuery, BoardgameModerator>
    {
        public CountBoardgameModeratorsQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IGenericRepository<BoardgameModerator> GetRepository(IUnitOfWork unitOfWork)
        {
            return unitOfWork.BoardgameModeratorsRepository;
        }
    }
}
