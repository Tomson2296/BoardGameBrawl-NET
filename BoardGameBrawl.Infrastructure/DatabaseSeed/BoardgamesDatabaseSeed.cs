using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence;
using System.Text;

namespace BoardGameBrawl.Infrastructure.DatabaseSeed
{
    public class BoardgamesDatabaseSeed
    {
        private readonly MainAppDBContext _context;
        private readonly IImageStream _imageStream;

        private readonly IBoardgameRepository _boardgameRepository;
        private readonly IBoardgameCategoriesRepository _boardgameCategoriesRepository;
        private readonly IBoardgameCategoryTagsRepository _boardgameCategoryTagsRepository;
        private readonly IBoardgameMechanicsRepository _boardgameMechanicsRepository;
        private readonly IBoardgameMechanicTagsRepository _boardgameMechanicTagsRepository;

        public BoardgamesDatabaseSeed(
            MainAppDBContext context, 
            IImageStream imageStream, 
            IBoardgameRepository boardgameRepository, 
            IBoardgameCategoriesRepository boardgameCategoriesRepository, 
            IBoardgameCategoryTagsRepository boardgameCategoryTagsRepository,
            IBoardgameMechanicsRepository boardgameMechanicsRepository,
            IBoardgameMechanicTagsRepository boardgameMechanicTagsRepository)
        {
            _context = context;
            _imageStream = imageStream;
            _boardgameRepository = boardgameRepository;
            _boardgameCategoriesRepository = boardgameCategoriesRepository;
            _boardgameCategoryTagsRepository = boardgameCategoryTagsRepository;
            _boardgameMechanicsRepository = boardgameMechanicsRepository;
            _boardgameMechanicTagsRepository = boardgameMechanicTagsRepository;
        }

        public async Task SeedDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            string catalog = Directory.GetCurrentDirectory().ToString();
            string filePath = catalog + "\\Resources\\top100_boardgames_data.csv";
            bool firstLine = true;

            using (StreamReader reader = new(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    string[] values = line!.Split(';');
                    int count = values.Length;

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
                    string imagePathFile = values[11];
                    string desc;

                    if (count > 13)
                    {
                        // recreate boardgame description 
                        StringBuilder descriptionBuilder = new StringBuilder();
                        descriptionBuilder.Append(values[12]);
                        for (int j = 13; j < count; j++)
                        {
                            descriptionBuilder.Append(";" + values[j].Trim());
                        }
                        desc = descriptionBuilder.ToString();
                    }
                    else
                    {
                        // no ; separation - copy description w/o problems
                        desc = values[12];
                    }

                    byte[] image = await _imageStream.ReadImageStreamAsync(imagePathFile);

                    // adding downloaded boardgame 
                    Boardgame entry = new()
                    {
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

                    await _boardgameRepository.AddEntity(entry);

                    // adding downloaded distinct boardgame categories
                    // adding relationship boardgame-boardgameCategory

                    foreach (var category in categories)
                    {
                        BoardgameCategory newCategory = new()
                        {
                            Category = category.Trim()
                        };
                        Guid categoryId;

                        if (await _boardgameCategoriesRepository.Exists(newCategory) == false)
                        {
                            categoryId = newCategory.Id;
                            await _boardgameCategoriesRepository.AddEntity(newCategory);
                        }
                        else
                        {
                            categoryId = await _boardgameCategoriesRepository.GetBoardgameCategoryIdAsync(newCategory.Category);
                        }

                        BoardgameCategoryTag newBoardgameCategoryTag = new()
                        {
                            BoardgameId = entry.Id,
                            CategoryId = categoryId
                        };

                        await _boardgameCategoryTagsRepository.AddEntity(newBoardgameCategoryTag);
                    }

                    // adding downloaded distinct boardgame mechanics 
                    // adding relationship boardgame-boardgameMechanic

                    foreach (var mechanic in mechanics)
                    {
                        BoardgameMechanic newMechanic = new()
                        {
                            Mechanic = mechanic.Trim()
                        };
                        Guid mechanicId;

                        if (await _boardgameMechanicsRepository.Exists(newMechanic) == false)
                        {
                            mechanicId = newMechanic.Id;
                            await _boardgameMechanicsRepository.AddEntity(newMechanic);
                        }
                        else
                        {
                            mechanicId = await _boardgameMechanicsRepository.GetBoardgameMechanicIdAsync(newMechanic.Mechanic);
                        }

                        BoardgameMechanicTag newBoardgameMechanicTag = new()
                        {
                            BoardgameId = entry.Id,
                            MechanicId = mechanicId
                        };

                        await _boardgameMechanicTagsRepository.AddEntity(newBoardgameMechanicTag);
                    }
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
