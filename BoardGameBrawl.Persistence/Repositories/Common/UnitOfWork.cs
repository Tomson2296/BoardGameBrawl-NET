#nullable disable

using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.Contracts.Entities.Group_Related;
using BoardGameBrawl.Application.Contracts.Entities.Match_Related;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Entities.Group_Related;
using BoardGameBrawl.Persistence.Repositories.Entities.Match_Related;
using BoardGameBrawl.Persistence.Repositories.Entities.Player_Related;
using Microsoft.AspNetCore.Http;

namespace BoardGameBrawl.Persistence.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly MainAppDBContext _context;
        protected readonly IHttpContextAccessor _contextAccessor;
        protected readonly IMapper _mapper; 

        private IPlayerRepository _playerRepository;
        private IPlayerPreferenceRepository _playerPreferenceRepository;
        private IPlayerFriendRepository _playerFriendRepository;
        private IPlayerCollectionRepository _playerCollectionRepository;
        private IPlayerFavouriteBGRepository _playerFavouriteGBRepository;

        private IBoardgameRepository _boardgameRepository;
        private IBoardgameDomainsRepository _boardgameDomainsRepository;
        private IBoardgameDomainTagsRepository _boardgameDomainTagsRepository;
        private IBoardgameCategoriesRepository _boardgameCategoriesRepository;
        private IBoardgameCategoryTagsRepository _boardgameCategoryTagsRepository;
        private IBoardgameMechanicsRepository _boardgameMechanicsRepository;
        private IBoardgameMechanicTagsRepository _boardgameMechanicTagsRepository;
        private IBoardgameModeratorsRepository _boardgameModeratorsRepository;

        private IGroupRepository _groupRepository;
        private IGroupParticipantRepository _groupParticipantRepository;

        private IMatchRuleRepository _matchRuleRepository;

        public UnitOfWork(MainAppDBContext context, 
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        // Player-related repositories 

        public IPlayerRepository PlayerRepository =>
            _playerRepository ??= new PlayerRepository(_context, _mapper);

        public IPlayerPreferenceRepository PlayerPreferenceRepository =>
            _playerPreferenceRepository ??= new PlayerPreferenceRepository(_context, _mapper);

        public IPlayerFriendRepository PlayerFriendRepository =>
            _playerFriendRepository ??= new PlayerFriendRepository(_context);

        public IPlayerCollectionRepository PlayerCollectionRepository =>
            _playerCollectionRepository ??= new PlayerCollectionRepository(_context, _mapper);

        public IPlayerFavouriteBGRepository PlayerFavouriteBGRepository =>
            _playerFavouriteGBRepository ??= new PlayerFavouriteBGRepository(_context, _mapper);


        // Boardgame-related repositories

        public IBoardgameRepository BoardgameRepository =>
            _boardgameRepository ??= new BoardgameRepository(_context, _mapper);

        public IBoardgameDomainsRepository BoardgameDomainsRepository =>
            _boardgameDomainsRepository ??= new BoardgameDomainsRepository(_context, _mapper);

        public IBoardgameDomainTagsRepository BoardgameDomainTagsRepository =>
            _boardgameDomainTagsRepository ??= new BoardgameDomainTagsRepository(_context, _mapper);

        public IBoardgameCategoriesRepository BoardgameCategoriesRepository =>
            _boardgameCategoriesRepository ??= new BoardgameCategoriesRepository(_context, _mapper);

        public IBoardgameCategoryTagsRepository BoardgameCategoryTagsRepository =>
            _boardgameCategoryTagsRepository ??= new BoardgameCategoryTagsRepository(_context, _mapper);

        public IBoardgameMechanicsRepository BoardgameMechanicsRepository =>
            _boardgameMechanicsRepository ??= new BoardgameMechanicsRepository(_context, _mapper);

        public IBoardgameMechanicTagsRepository BoardgameMechanicsTagsRepository =>
            _boardgameMechanicTagsRepository ??= new BoardgameMechanicTagsRepository(_context, _mapper);

        public IBoardgameModeratorsRepository BoardgameModeratorsRepository =>
            _boardgameModeratorsRepository ??= new BoardgameModeratorsRepository(_context, _mapper);


        // Group-related repositories

        public IGroupRepository GroupRepository =>
            _groupRepository ??= new GroupRepository(_context, _mapper);
        
        public IGroupParticipantRepository GroupParticipantRepository =>
           _groupParticipantRepository ??= new GroupParticipantRepository(_context, _mapper);


        // Match-related repositories

        public IMatchRuleRepository MatchRuleRepository =>
            _matchRuleRepository ??= new MatchRuleRepository(_context, _mapper);



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
