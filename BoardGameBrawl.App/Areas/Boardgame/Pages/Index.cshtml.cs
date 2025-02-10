#nullable disable
using AspNetCoreGeneratedDocument;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategories.Commands.AddBoardgameCategory;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategories.Queries.CheckIfBoardgameCategoryExists;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategories.Queries.GetBoardgameCategoryId;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategoryTags.Commands.AddBoardgameCategoryTag;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategoryTags.Queries.GetBoardgameCategories;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomains.Commands.AddBoardgameDomain;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomains.Queries.CheckIfBoardgameDomainExists;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomains.Queries.GetBoardgameDomainId;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomainTags.Commands.AddBoardgameDomainTag;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomainTags.Queries.GetBoardgameDomains;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanics.Commands.AddBoardgameMechanic;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanics.Queries.CheckIfBoardgameMechanicExists;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanics.Queries.GetBoardgameMechanicId;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanicTags.Commands.AddBoardgameMechanicTag;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanicTags.Queries.GetBoardgameMechanics;
using BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Commands.AddBoardgame;
using BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.CheckIfBoardgameExists;
using BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgameByBGGId;
using BoardGameBrawl.Application.Services.String;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Domain.Value_objects;
using BoardGameBrawl.Infrastructure.Services.BGGService;
using BoardGameBrawl.Infrastructure.Services.ImageDownloader;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.Boardgame.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBGGService _BGGAPIService;
        private readonly IImageDownloaderService _imageDownloaderService;
        private readonly IMediator _mediator;
        private readonly IStringCleaner _stringCleaner;
        private readonly IStringFormatter _stringFormatter;

        public IndexModel(UserManager<ApplicationUser> userManager,
            IBGGService bGGAPIService,
            IImageDownloaderService imageDownloaderService,
            IMediator mediator, IStringCleaner stringCleaner,
            IStringFormatter stringFormatter)
        {
            _userManager = userManager;
            _BGGAPIService = bGGAPIService;
            _imageDownloaderService = imageDownloaderService;
            _mediator = mediator;
            _stringCleaner = stringCleaner;
            _stringFormatter = stringFormatter;
        }

        [BindProperty(SupportsGet = true)]
        public int BoardgameId { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        
        public BoardgameDTO BoardgameDTO { get; set; }

        public IList<BoardgameDomainDTO> BoardgameDomainDTOs { get; set; }
        
        public IList<BoardgameCategoryDTO> BoardgameCategoryDTOs { get; set; }

        public IList<BoardgameMechanicDTO> BoardgameMechanicDTOs { get; set; }

        public bool IsBoardgameExistsInDB { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var checkIfBoardgameExistQuery = new CheckIfBoardgameExistsQuery { Id = BoardgameId };
            IsBoardgameExistsInDB = await _mediator.Send(checkIfBoardgameExistQuery);

            if (!IsBoardgameExistsInDB)
            {
                await AddBoardgameToDatabase();
                await LoadBoardgameDTOs();
            }
            else
            {
                await LoadBoardgameDTOs();
            }

            return Page();
        }

        private async Task LoadBoardgameDTOs()
        {
            var getBoardgameByBGGIdQuery = new GetBoardgameByBGGIdQuery { BGGId = BoardgameId };
            BoardgameDTO = await _mediator.Send(getBoardgameByBGGIdQuery);

            // get boardgame domains 
            var getBoardgameDomains = new GetBoardgameDomainsQuery { BoardgameId = BoardgameDTO.Id };
            BoardgameDomainDTOs = await _mediator.Send(getBoardgameDomains);

            // get boardmage categories
            var getBoardgameCategories = new GetBoardgameCategoriesQuery { BoardgameId = BoardgameDTO.Id };
            BoardgameCategoryDTOs = await _mediator.Send(getBoardgameCategories);

            //get boardgame mechanics
            var getBoardgameMechanics = new GetBoardgameMechanicsQuery { BoardgameId = BoardgameDTO.Id };
            BoardgameMechanicDTOs = await _mediator.Send(getBoardgameMechanics);
        }

        private async Task<IActionResult> AddBoardgameToDatabase()
        {
            try
            {
                // add new boardgame to database
                BoardgameItemResponse boardgame = await _BGGAPIService.GetBGGBoardGameInfoAsync(BoardgameId);
                string boardgameDescription = _stringCleaner.CleanDescription(boardgame.Item.Description);
                string gameName = boardgame.Item.Names.Where(l => l.Type == "primary").First().Value;

                // create boardgameDTO object 
                BoardgameDTO boardgameObject = new()
                {
                    Id = Guid.NewGuid(),
                    Name = gameName,
                    BGGId = boardgame.Item.Id,
                    Description = boardgameDescription,
                    AverageBGGWeight = ((float)boardgame.Item.Statistics.Rating.AverageWeight.Value),
                    MaximumPlayingTime = ((short)boardgame.Item.MaxPlayTime.Value),
                    MaxPlayers = ((byte)boardgame.Item.MaxPlayers.Value),
                    MinimumPlayingTime = ((short)boardgame.Item.MinPlayTime.Value),
                    MinPlayers = ((byte)boardgame.Item.MinPlayers.Value),
                    PlayingTime = ((short)boardgame.Item.PlayingTime.Value),
                    MinAge = ((byte)boardgame.Item.MinAge.Value),
                    YearPublished = ((short)boardgame.Item.YearPublished.Value),
                    AverageRating = ((float)boardgame.Item.Statistics.Rating.Average.Value),
                    BayesRating = ((float)boardgame.Item.Statistics.Rating.BayesAverage.Value),
                    Owned = boardgame.Item.Statistics.Rating.Owned.Value
                };

                // download boardgame image
                string boardgameImageUrl = boardgame.Item.Image;
                byte[] image = await _imageDownloaderService.DownloadImageAsync(boardgameImageUrl);
                boardgameObject.Image = image;

                // add boardgame to database 
                var addBoardgameCommand = new AddBoardgameCommand { BoardgameDTO = boardgameObject };
                var addBoardgameResult = await _mediator.Send(addBoardgameCommand);

                if (!addBoardgameResult.Success)
                {
                    ModelState.AddModelError("Command", addBoardgameResult.Message);
                    StatusMessage = "Error: " + addBoardgameResult.Message;
                    return Page();
                }

                // add boardgame domains - format boardgamedomains before adding to database using StringFormatter
                List<string> boardgameDomains = boardgame.Item.Statistics.Rating.Ranks.Where(r => r.Type == "family").Select(r => r.Name).ToList();
                
                List<string> formattedDomains = new List<string>();
                foreach (var domainDesc in boardgameDomains)
                {
                    var formattedString = _stringFormatter.FormatString(domainDesc);
                    formattedDomains.Add(formattedString);
                }

                foreach (var domain in formattedDomains)
                {
                    BoardgameDomainDTO boardgameDomain = new()
                    {
                        Domain = domain
                    };

                    var checkQuery = new CheckIfBoardgameDomainExistsQuery { BoardgameDomainDTO = boardgameDomain };
                    bool domainExists = await _mediator.Send(checkQuery);

                    if (domainExists)
                    {
                        var getDomainId = new GetBoardgameDomainIdQuery { DomainName = domain };
                        boardgameDomain.Id = await _mediator.Send(getDomainId);
                    }
                    else
                    {
                        boardgameDomain.Id = Guid.NewGuid();
                        var addDomainCommand = new AddBoardgameDomainCommand{ BoardgameDomainDTO = boardgameDomain };
                        var addBoardgameDomainResult = await _mediator.Send(addDomainCommand);

                        if (!addBoardgameDomainResult.Success)
                        {
                            ModelState.AddModelError("Command", addBoardgameDomainResult.Message);
                            StatusMessage = "Error: " + addBoardgameDomainResult.Message;
                            return Page();
                        }
                    }

                    BoardgameDomainTagDTO newBoardgameDomainTag = new()
                    {
                        BoardgameId = boardgameObject.Id,
                        BoardgameName = boardgameObject.Name,
                        DomainId = boardgameDomain.Id,
                        DomainName = boardgameDomain.Domain
                    };

                    var addBoardgameDomainTagCommand = new AddBoardgameDomainTagCommand { BoardgameDomainTagDTO = newBoardgameDomainTag };
                    var addBoardgameDomainTagResult = await _mediator.Send(addBoardgameDomainTagCommand);

                    if (!addBoardgameDomainTagResult.Success)
                    {
                        ModelState.AddModelError("Command", addBoardgameDomainTagResult.Message);
                        StatusMessage = "Error: " + addBoardgameDomainTagResult.Message;
                        return Page();
                    }
                }

                // add boardgamecategories
                // get list of boardgame categories 
                List<string> boardgameCategories = boardgame.Item.Links.Where(l => l.Type == "boardgamecategory").Select(l => l.Value).ToList();

                // iterate on every category
                foreach (var category in boardgameCategories)
                {
                    // create boardgamecategory object
                    BoardgameCategoryDTO boardgameCategory = new()
                    {
                        Category = System.Web.HttpUtility.HtmlDecode(category).Trim()
                    };

                    // check if category exists in database
                    var checkQuery = new CheckIfBoardgameCategoryExistsQuery { BoardgameCategoryDTO = boardgameCategory };
                    bool categoryExists = await _mediator.Send(checkQuery);

                    if (categoryExists)
                    {
                        // if exists - get that category id
                        var getCategoryId = new GetBoardgameCategoryIdQuery { CategoryName = category };
                        boardgameCategory.Id = await _mediator.Send(getCategoryId);
                    }
                    else
                    {
                        // if not create new boardgame category and add new category
                        boardgameCategory.Id = Guid.NewGuid();
                        var addCategoryCommand = new AddBoardgameCategoryCommand { BoardgameCategoryDTO = boardgameCategory };
                        var addBoardgameCategoryResult = await _mediator.Send(addCategoryCommand);

                        if (!addBoardgameCategoryResult.Success)
                        {
                            ModelState.AddModelError("Command", addBoardgameCategoryResult.Message);
                            StatusMessage = "Error: " + addBoardgameCategoryResult.Message;
                            return Page();
                        }
                    }

                    // create BoardgameCategoryTag, add it to database
                    BoardgameCategoryTagDTO newBoardgameCategoryTag = new()
                    {
                        BoardgameId = boardgameObject.Id,
                        BoardgameName = boardgameObject.Name,
                        CategoryId = boardgameCategory.Id,
                        CategoryName = boardgameCategory.Category
                    };

                    var addBoardgameCategoryTagCommand = new AddBoardgameCategoryTagCommand { BoardgameCategoryTagDTO = newBoardgameCategoryTag };
                    var addBoardgameCategoryTagResult = await _mediator.Send(addBoardgameCategoryTagCommand);

                    if (!addBoardgameCategoryTagResult.Success)
                    {
                        ModelState.AddModelError("Command", addBoardgameCategoryTagResult.Message);
                        StatusMessage = "Error: " + addBoardgameCategoryTagResult.Message;
                        return Page();
                    }
                }
                
                // add boardgame mechanics second
                List<string> boardgameMechanics = boardgame.Item.Links.Where(l => l.Type == "boardgamemechanic").Select(l => l.Value).ToList();

                foreach (var mechanic in boardgameMechanics)
                {
                    BoardgameMechanicDTO boardgameMechanic = new()
                    {
                        Mechanic = System.Web.HttpUtility.HtmlDecode(mechanic).Trim()
                    };

                    var checkQuery = new CheckIfBoardgameMechanicExistsQuery { BoardgameMechanicDTO = boardgameMechanic };
                    bool mechanicExists = await _mediator.Send(checkQuery);

                    if (mechanicExists)
                    {
                        var getMechanicId = new GetBoardgameMechanicIdQuery { MechanicName = mechanic };
                        boardgameMechanic.Id = await _mediator.Send(getMechanicId);
                    }
                    else
                    {
                        boardgameMechanic.Id = Guid.NewGuid();
                        var addMechanicCommand = new AddBoardgameMechanicCommand { BoardgameMechanicDTO = boardgameMechanic };
                        var addBoardgameMechanicResult = await _mediator.Send(addMechanicCommand);

                        if (!addBoardgameMechanicResult.Success)
                        {
                            ModelState.AddModelError("Command", addBoardgameMechanicResult.Message);
                            StatusMessage = "Error: " + addBoardgameMechanicResult.Message;
                            return Page();
                        }
                    }

                    BoardgameMechanicTagDTO newBoardgameMechanicTag = new()
                    {
                        BoardgameId = boardgameObject.Id,
                        BoardgameName = boardgameObject.Name,
                        MechanicId = boardgameMechanic.Id,
                        MechanicName = boardgameMechanic.Mechanic
                    };

                    var addBoardgameMechanicTagCommand = new AddBoardgameMechanicTagCommand { BoardgameMechanicTagDTO = newBoardgameMechanicTag };
                    var addBoardgameMechanicTagResult = await _mediator.Send(addBoardgameMechanicTagCommand);

                    if (!addBoardgameMechanicTagResult.Success)
                    {
                        ModelState.AddModelError("Command", addBoardgameMechanicTagResult.Message);
                        StatusMessage = "Error: " + addBoardgameMechanicTagResult.Message;
                        return Page();
                    }
                }

                StatusMessage = "Boardgame added to database";
                return Page();
            }
            catch (Exception ex)
            {
                StatusMessage = "Error - An unexpected error occurred while adding boardgame to DB: " + ex.Message;
                return Page();
            }
        }
    }
}
