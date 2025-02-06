using BoardGameBrawl.Domain.Value_objects;

namespace BoardGameBrawl.Infrastructure.Services.BGGService
{
    public interface IBGGService
    {
        public Task<BoardgameItemResponse?> GetBGGBoardGameInfoAsync(int bggBoardGameId);
        
        public Task<BoardgameCollectionResponse?> GetUserBGGCollectionInfoAsync(string bggUsername);
    }
}
