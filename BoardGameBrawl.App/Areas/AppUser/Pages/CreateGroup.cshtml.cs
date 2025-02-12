#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.Features.Group_Related.Group.Commands.AddGroup;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BoardGameBrawl.App.Areas.AppUser.Pages
{
    public class CreateGroupModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public CreateGroupModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [MaxLength(256)]
            [Display(Name = "Group Name")]
            public string GroupName { get; set; }

            [Display(Name = "Group Description")]
            [MaxLength(2048)]
            public string GroupDesc { get; set; }

            [Display(Name = "Group Miniature")]
            public byte[] GroupMiniature { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Input = new InputModel
            {
                GroupName = string.Empty,
                GroupDesc = string.Empty,
                GroupMiniature = default
            };

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
                // create new PlayerDTO object
                GroupDTO groupDTO = new()
                {
                    Id = Guid.NewGuid(),
                    GroupName = Input.GroupName,
                    GroupDescription = Input.GroupDesc
                };

                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    var imageResult = await ProcessFileUploadAsync(file);

                    if (!imageResult.Success)
                    {
                        ModelState.AddModelError("File", imageResult.ErrorMessage);
                        StatusMessage = "Error: " + imageResult.ErrorMessage;
                        return Page();
                    }

                    groupDTO.GroupMiniature = imageResult.FileData;
                }

                //Use MediatR to Send the Command
                var command = new AddGroupCommand { GroupDTO = groupDTO };
                var response = await _mediator.Send(command);

                if (!response.Success)
                {
                    ModelState.AddModelError("Command", response.Message);
                    StatusMessage = "Error: " + response.Message;
                    return Page();
                }

                StatusMessage = "Group Profile Created Successfully";
                return RedirectToPage("/Groups", new { area = "AppUser" });
            }
            catch (Exception ex)
            {
                StatusMessage = "Error - An unexpected error occurred while creating group profile: " + ex.Message;
                return RedirectToPage("/Groups", new { area = "AppUser" });
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