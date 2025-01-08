#nullable disable

using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Entities.Player_Related;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace BoardGameBrawl.Persistence.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainAppDBContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        private IPlayerRepository _playerRepository;

        private IBoardgameRepository _boardgameRepository;
        private IBoardgameCategoriesRepository _boardgameCategoriesRepository;
        private IBoardgameCategoryTagsRepository _boardgameCategoryTagsRepository;
        private IBoardgameMechanicsRepository _boardgameMechanicsRepository;
        private IBoardgameMechanicTagsRepository _boardgameMechanicTagsRepository;

        public UnitOfWork(MainAppDBContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        // Player-related repositories 

        public IPlayerRepository PlayerRepository =>
            _playerRepository ??= new PlayerRepository(_context);


        // Boardgame-related repositories

        public IBoardgameRepository BoardgameRepository =>
            _boardgameRepository ??= new BoardgameRepository(_context);

        public IBoardgameMechanicsRepository BoardgameMechanicsRepository =>
            _boardgameMechanicsRepository ??= new BoardgameMechanicsRepository(_context);

        public IBoardgameMechanicTagsRepository BoardgameMechanicsTagsRepository =>
            _boardgameMechanicTagsRepository ??= new BoardgameMechanicTagsRepository(_context);

        public IBoardgameCategoriesRepository BoardgameCategoryRepository =>
            _boardgameCategoriesRepository ??= new BoardgameCategoriesRepository(_context);

        public IBoardgameCategoryTagsRepository BoardgameCategoryTagsRepository =>
            _boardgameCategoryTagsRepository ??= new BoardgameCategoryTagsRepository(_context);


        public async Task CommitChangesAsync()
        {
            var username = _contextAccessor.HttpContext.User.Identity.Name.ToString();
            await _context.SaveChangesAsync(username);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
