#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Player_Related.Players.Commands.UpdatePlayerAvatar;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayer;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.Identity.Pages.Account.Manage
{
    public class ChangePlayerAvatarModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public ChangePlayerAvatarModel(UserManager<ApplicationUser> userManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public byte[] ProfileAvatar { get; set; }
        }

        [TempData]
        public string StatusMessage { get; set; }

        public PlayerDTO TargetPlayerProfile { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var query = new GetPlayerQuery { Id = Id };
            TargetPlayerProfile = await _mediator.Send(query);
            if (TargetPlayerProfile == null)
            {
                return NotFound();
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            try
            {
                var query = new GetPlayerQuery { Id = Id };
                TargetPlayerProfile = await _mediator.Send(query);

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
                    Input.ProfileAvatar = avatarResult.FileData;
                }

                TargetPlayerProfile.UserAvatar = Input.ProfileAvatar;

                var command = new UpdatePlayerAvatarCommand { PlayerDTO = TargetPlayerProfile };
                var response = await _mediator.Send(command);

                if (!response.Success)
                {
                    ModelState.AddModelError("Command", response.Message);
                    StatusMessage = "Error: " + response.Message;
                    return Page();
                }

                StatusMessage = "Player Profile Avatar updated successfully";
                return RedirectToPage("/Account/Manage/PlayerProfile", new { area = "Identity", Id = Id });
            }
            catch (Exception ex)
            {
                StatusMessage = "Error - An unexpected error occurred while updating player avatar: " + ex.Message;
                return RedirectToPage("/Account/Manage/PlayerProfile", new { area = "Identity", Id = Id });
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
