using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Identity;
using BoardGameBrawl.Persistence;

namespace BoardGameBrawl.Infrastructure.DatabaseSeed
{
    public class BoardgamesDatabaseSeed
    {
        private readonly IdentityAppDBContext _context;
        private readonly IImageStream _imageStream;

        public BoardgamesDatabaseSeed(
            IdentityAppDBContext context, 
            IImageStream imageStream)
        {
            _context = context;
            _imageStream = imageStream;
        }


        public async Task SeedDatabaseAsync(MainAppDBContext context)
        {
            await _context.Database.EnsureCreatedAsync();

            string catalog = Directory.GetCurrentDirectory().ToString();
            string filePath = catalog + "\\Resources\\top100_boardgames_data.csv";
            Console.WriteLine(filePath);

            bool firstLine = true;

            using (StreamReader reader = new(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line!.Split(',');

                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    bool BBGID_parse = int.TryParse(values[0], out int BGGId);
                    string name = values[1];
                    bool yearPublished_parse = short.TryParse(values[2], out short yearPublished);
                    bool minPlayer_parse = byte.TryParse(values[3], out byte minPlayers);
                    bool maxPlayer_parse = byte.TryParse(values[4], out byte maxPlayers);
                    bool playingTime_parse = short.TryParse(values[5], out short playingTime);
                    bool minPlayingTime_parse = short.TryParse(values[6], out short minPlayingTime);
                    bool maxPlayingTime_parse = short.TryParse(values[7], out short maxPPlayingTime);
                    bool averageWeight_parse = float.TryParse(values[8], out float BGGWeight);

                    string[] categories = values[9].Split(",");
                    string[] mechanics = values[10].Split(",");
                    string desc = values[11];
                    string imagePathFile = values[12];

                    byte[] image = await _imageStream.ReadImageStreamAsync(imagePathFile);

                    Boardgame entry = new()
                    {
                        Id = Guid.NewGuid(),
                        BGGId = BGGId,
                        Name = name,
                        YearPublished = yearPublished,
                        MinPlayers = minPlayers,
                        MaxPlayers = maxPlayers,
                        PlayingTime = playingTime,
                        MinimumPlayingTime = minPlayingTime,
                        MaximumPlayingTime = maxPPlayingTime,
                        BGGWeight = BGGWeight,
                        Description = desc,
                        Image = image
                    };
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
