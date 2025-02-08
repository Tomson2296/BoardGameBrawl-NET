#nullable disable
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BoardGameBrawl.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Player_Related.Players.Commands.AddPlayer;
using BoardGameBrawl.Persistence.Extensions;
using Azure;

namespace BoardGameBrawl.App.Areas.Identity.Pages.Account.Manage
{
    public class CreatePlayerProfile : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserStore<ApplicationUser> _userStore;
        private readonly IMediator _mediator;
        private readonly ILogger<CreatePlayerProfile> _logger;

        public CreatePlayerProfile(UserManager<ApplicationUser> userManager, 
            IApplicationUserStore<ApplicationUser> userStore,
            IMediator mediator,
            ILogger<CreatePlayerProfile> logger)
        {
            _userManager = userManager;
            _userStore = userStore;
            _mediator = mediator;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "UserName")]
            public string UserName { get; set; }

            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "FirstName")]
            public string FirstName { get; set; }

            [Display(Name = "LastName")]
            public string LastName { get; set; }

            [Display(Name = "BGGUsername")]
            public string BGGUsername { get; set; }

            [Display(Name = "UserDescription")]
            public string UserDescription { get; set; }

            [Display(Name = "UserAvatar")]
            public byte[] UserAvatar { get; set; }
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{ _userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userStore.GetUserNameAsync(user, CancellationToken.None);
            var email = await _userStore.GetEmailAsync(user, CancellationToken.None);

            Input = new InputModel
            {
                UserName = userName,
                Email = email
            };
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            try
            {
                // create new PlayerDTO object
                PlayerDTO playerDTO = new()
                {
                    Id = Guid.NewGuid(),
                    ApplicationUserId = user.Id,
                    PlayerName = Input.UserName,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    BGGUsername = Input.BGGUsername,
                    UserDescription = Input.UserDescription
                };

                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    var avatarResult = await ProcessFileUploadAsync(file);

                    if (!avatarResult.Success)
                    {
                        ModelState.AddModelError("File", avatarResult.ErrorMessage);
                        StatusMessage = "Error: " + avatarResult.ErrorMessage;
                        return Page();
                    }

                    playerDTO.UserAvatar = avatarResult.FileData;
                }

                // Use MediatR to Send the Command
                var command = new AddPlayerCommand { PlayerDTO = playerDTO };
                var response = await _mediator.Send(command);

                if (!response.Success)
                {
                    ModelState.AddModelError("Command", response.Message);
                    StatusMessage = "Error: " + response.Message;
                    return Page();
                }

                await _userStore.SetUserIsPlayerAccountCreatedAsync(user, true);
                await _userManager.UpdateAsync(user);

                StatusMessage = "Player Profile Created Successfully";
                return RedirectToPage("/Account/Manage/Index", new { area = "Identity" });
            }
            catch (Exception ex)
            {
                StatusMessage = "Error - An unexpected error occurred while creating player profile: " + ex.Message;
                return RedirectToPage("/Account/Manage/Index", new { area = "Identity" });
            }
        }

        public class FileUploadResult
        {
            public bool Success { get; set; }
            public byte[] FileData { get; set; }
            public string ErrorMessage { get; set; }
        }

        private async Task<FileUploadResult> ProcessFileUploadAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return new FileUploadResult { Success = false, ErrorMessage = "No file uploaded." };
            }

            if (file.Length > 2 * 1024 * 1024) // 2MB Limit
            {
                return new FileUploadResult { Success = false, ErrorMessage = "The file is too large." };
            }

            using var dataStream = new MemoryStream();
            await file.CopyToAsync(dataStream);

            return new FileUploadResult { Success = true, FileData = dataStream.ToArray() };
        }
    }
}
