using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.Services.String;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Text;

namespace BoardGameBrawl.Infrastructure.DatabaseSeed
{
    public class BoardgamesDatabaseSeed
    {
        private readonly MainAppDBContext _context;
        private readonly IImageStream _imageStream;

        private readonly IBoardgameRepository _boardgameRepository;
        private readonly IBoardgameDomainsRepository _boardgameDomainsRepository;
        private readonly IBoardgameDomainTagsRepository _boardgameDomainTagsRepository;
        private readonly IBoardgameCategoriesRepository _boardgameCategoriesRepository;
        private readonly IBoardgameCategoryTagsRepository _boardgameCategoryTagsRepository;
        private readonly IBoardgameMechanicsRepository _boardgameMechanicsRepository;
        private readonly IBoardgameMechanicTagsRepository _boardgameMechanicTagsRepository;
        private readonly IStringCleaner _stringCleaner;

        public BoardgamesDatabaseSeed(MainAppDBContext context,
            IImageStream imageStream,
            IBoardgameRepository boardgameRepository,
            IBoardgameDomainsRepository boardgameDomainsRepository,
            IBoardgameDomainTagsRepository boardgameDomainTagsRepository,
            IBoardgameCategoriesRepository boardgameCategoriesRepository,
            IBoardgameCategoryTagsRepository boardgameCategoryTagsRepository,
            IBoardgameMechanicsRepository boardgameMechanicsRepository,
            IBoardgameMechanicTagsRepository boardgameMechanicTagsRepository,
            IStringCleaner stringCleaner)
        {
            _context = context;
            _imageStream = imageStream;
            _boardgameRepository = boardgameRepository;
            _boardgameDomainsRepository = boardgameDomainsRepository;
            _boardgameDomainTagsRepository = boardgameDomainTagsRepository;
            _boardgameCategoriesRepository = boardgameCategoriesRepository;
            _boardgameCategoryTagsRepository = boardgameCategoryTagsRepository;
            _boardgameMechanicsRepository = boardgameMechanicsRepository;
            _boardgameMechanicTagsRepository = boardgameMechanicTagsRepository;
            _stringCleaner = stringCleaner;
        }

        public async Task SeedDatabaseAsync()
        {
            //await _context.Database.EnsureCreatedAsync();

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
                    bool minAge_parse = byte.TryParse(values[8], out byte minAge);
                    bool averageWeight_parse = float.TryParse(values[9], out float BGGWeight);
                    bool rank_parse = int.TryParse(values[10], out int rank);
                    bool averageRating_parse = float.TryParse(values[11], out float averageRating);
                    bool bayesRating_parse = float.TryParse(values[12], out float bayesRating);
                    bool owning_parse = int.TryParse(values[13], out int owning);

                    string[] domains = values[14].Split(',');
                    string[] categories = values[15].Split(",");
                    string[] mechanics = values[16].Split(",");
                    string imagePathFile = values[17];
                    string desc;

                    if (count > 19)
                    {
                        // recreate boardgame description 
                        StringBuilder descriptionBuilder = new StringBuilder();
                        descriptionBuilder.Append(values[18]);
                        for (int j = 19; j < count; j++)
                        {
                            descriptionBuilder.Append(values[j]);
                        }
                        desc = _stringCleaner.CleanDescription(descriptionBuilder.ToString());
                    }
                    else
                    {
                        // no ; separation - copy description w/o problems
                        // clean string
                        desc = _stringCleaner.CleanDescription(values[18]);
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
                        MinAge = minAge,
                        PlayingTime = playingTime,
                        MinimumPlayingTime = minPlayingTime,
                        MaximumPlayingTime = maxPPlayingTime,
                        AverageBGGWeight = BGGWeight,
                        Rank = rank,
                        AverageRating = averageRating,
                        BayesRating = bayesRating,
                        Owned = owning,
                        Description = desc,
                        Image = image
                    };

                    await _boardgameRepository.AddEntity(entry);

                    // adding downloaded distinct boardgame domains
                    // adding relationship boardgame-boardgameDomain

                    foreach (var domain in domains)
                    {
                        BoardgameDomain newDomain = new()
                        {
                            Domain = domain.Trim()
                        };
                        Guid domainId;

                        if (await _boardgameDomainsRepository.Exists(newDomain) == false)
                        {
                            domainId = newDomain.Id;
                            await _boardgameDomainsRepository.AddEntity(newDomain);
                        }
                        else
                        {
                            domainId = await _boardgameDomainsRepository.GetBoardgameDomainIdAsync(newDomain.Domain);
                        }

                        BoardgameDomainTag newBoardgameDomainTag = new()
                        {
                            BoardgameId = entry.Id,
                            BoardgameName = entry.Name,
                            DomainId = domainId,
                            DomainName = newDomain.Domain
                        };

                        await _boardgameDomainTagsRepository.AddEntity(newBoardgameDomainTag);
                    }


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
                            BoardgameName = entry.Name,
                            CategoryId = categoryId,
                            CategoryName = newCategory.Category
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
                            BoardgameName = entry.Name,
                            MechanicId = mechanicId,
                            MechanicName = newMechanic.Mechanic
                        };

                        await _boardgameMechanicTagsRepository.AddEntity(newBoardgameMechanicTag);
                    }
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
