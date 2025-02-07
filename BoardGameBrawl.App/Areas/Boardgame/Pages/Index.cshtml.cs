#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategories.Commands.AddBoardgameCategory;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategories.Queries.CheckIfBoardgameCategoryExists;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategories.Queries.GetBoardgameCategoryId;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategoryTags.Commands.AddBoardgameCategoryTag;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanics.Commands.AddBoardgameMechanic;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanics.Queries.CheckIfBoardgameMechanicExists;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanics.Queries.GetBoardgameMechanicId;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanicTags.Commands.AddBoardgameMechanicTag;
using BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Commands.AddBoardgame;
using BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.CheckIfBoardgameExists;
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

        public IndexModel(UserManager<ApplicationUser> userManager,
            IBGGService bGGAPIService,
            IImageDownloaderService imageDownloaderService,
            IMediator mediator)
        {
            _userManager = userManager;
            _BGGAPIService = bGGAPIService;
            _imageDownloaderService = imageDownloaderService;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public int BoardgameId { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        
        public BoardgameItemResponse Boardgame { get; set; }

        public bool IsBoardgameExistsInDB { get; set; }

        public IList<string> BoardgameDescription { get; set; } 

        public string BoardgameImageUrl { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Boardgame = await _BGGAPIService.GetBGGBoardGameInfoAsync(BoardgameId);
            BoardgameDescription = await GetBoardgameDescription(Boardgame.Item.Description);

            var checkIfBoardgameExistQuery = new CheckIfBoardgameExistsQuery { Id = BoardgameId };
            IsBoardgameExistsInDB = await _mediator.Send(checkIfBoardgameExistQuery);

            if (!IsBoardgameExistsInDB)
            {
                await AddBoardgameToDatabase();
            }
            return Page();
        }

        private async Task<IActionResult> AddBoardgameToDatabase()
        {
            try
            {
                // create boardgameDTO object 
                BoardgameDTO boardgameObject = new()
                {
                    Id = Guid.NewGuid(),
                    BGGId = Boardgame.Item.Id,
                    Description = Boardgame.Item.Description,
                    BGGWeight = ((float)Boardgame.Item.Statistics.Rating.AverageWeight.Value),
                    MaximumPlayingTime = ((short)Boardgame.Item.MaxPlayTime.Value),
                    MaxPlayers = ((byte)Boardgame.Item.MaxPlayers.Value),
                    MinimumPlayingTime = ((short)Boardgame.Item.MinPlayTime.Value),
                    MinPlayers = ((byte)Boardgame.Item.MinPlayers.Value),
                    Name = Boardgame.Item.Names.Select(u => u.Type == "primary").Single().ToString(),
                    PlayingTime = ((short)Boardgame.Item.PlayingTime.Value),
                    YearPublished = ((short)Boardgame.Item.YearPublished.Value)
                };

                // download boardgame image
                BoardgameImageUrl = Boardgame.Item.Image;
                byte[] image = await _imageDownloaderService.DownloadImageAsync(BoardgameImageUrl);
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

                // add boardgamecategories first
                // get list of boardgame categories 
                List<string> boardgameCategories = Boardgame.Item.Links.Where(l => l.Type == "boardgamecategory").Select(l => l.Value).ToList();

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
                        CategoryId = boardgameCategory.Id
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
                List<string> boardgameMechanics = Boardgame.Item.Links.Where(l => l.Type == "boardgamemechanic").Select(l => l.Value).ToList();
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
                        MechanicId = boardgameMechanic.Id
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

                return Page();
            }
            catch (Exception ex)
            {
                StatusMessage = "Error - An unexpected error occurred while adding boardgame to DB: " + ex.Message;
                return Page();
            }
        }
        
        private Task<IList<string>> GetBoardgameDescription(string boardgameDesc)
        {
            IList<string> modifiedDescString = new List<string>();

            string breakingLineString = "&#10;";

            if (boardgameDesc.Contains(breakingLineString))
            {
                modifiedDescString = boardgameDesc.Split(breakingLineString);
            }

            for (int i = 0; i < modifiedDescString.Count; i++)
            {
                string oldString = modifiedDescString.ElementAt(i).ToString();
                if (string.IsNullOrEmpty(oldString)) continue;
                string decodedString = System.Web.HttpUtility.HtmlDecode(modifiedDescString.ElementAt(i));
                modifiedDescString[i] = decodedString;
            }
            return Task.FromResult(modifiedDescString);
        }
    }
}
