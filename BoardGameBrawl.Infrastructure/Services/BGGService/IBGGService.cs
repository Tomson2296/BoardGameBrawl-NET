using BoardGameBrawl.Domain.Value_objects;

namespace BoardGameBrawl.Infrastructure.Services.BGGService
{
    public interface IBGGService
    {
        public Task<BoardgameItem> GetBGGBoardGameInfoAsync(int BGGBoardGameID);
        
        public Task<BoardGameCollection> GetUserBGGCollectionInfoAsync(string BGGUserName);
    }
}
