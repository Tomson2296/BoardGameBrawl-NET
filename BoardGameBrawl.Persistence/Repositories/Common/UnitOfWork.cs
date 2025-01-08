using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using Microsoft.AspNetCore.Http;

namespace BoardGameBrawl.Persistence.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainAppDBContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public UnitOfWork(MainAppDBContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public IPlayerRepository PlayerRepository => throw new NotImplementedException();

        public IBoardgameRepository BoardgameRepository => throw new NotImplementedException();

        public IBoardgameMechanicsRepository BoardgameMechanicsRepository => throw new NotImplementedException();

        public IBoardgameMechanicTagsRepository BoardgameMechanicsTagsRepository => throw new NotImplementedException();

        public IBoardgameCategoriesRepository BoardgameCategoryRepository => throw new NotImplementedException();

        public IBoardgameCategoryTagsRepository BoardgameCategoryTagsRepository => throw new NotImplementedException();


        public Task<bool> CommitChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
