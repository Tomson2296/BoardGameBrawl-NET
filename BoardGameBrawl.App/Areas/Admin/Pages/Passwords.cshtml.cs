#nullable disable

using AutoMapper;
using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BoardGameBrawl.App.Areas.Admin.Pages
{
    public class PasswordsModel : AdminPageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public PasswordsModel(UserManager<ApplicationUser> userManager, 
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<ViewUserDTO> Users;


        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }


        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; }


        public int PageSize { get; set; } = 20;

        public int TotalUsersNumber { get; set; }

        public int PreviousNumber { get; set; }

        public int NextNumber { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Filter.IsNullOrEmpty())
            {
                Users = await _userManager.Users.Where(u => Filter == null || u.UserName.Contains(Filter)).AsNoTracking().Select(u => new ViewUserDTO{ Id = u.Id, UserName = u.UserName, Email = u.Email})
                    .OrderBy(u => u.UserName).Skip(PageSize * (PageNumber - 1)).Take(PageSize).ToListAsync();
                TotalUsersNumber = _userManager.Users.Count();
            }
            else
            {
                Users = await _userManager.Users.Where(u => Filter == null || u.UserName.Contains(Filter)).AsNoTracking().Select(u => new ViewUserDTO { Id = u.Id, UserName = u.UserName, Email = u.Email })
                    .OrderBy(u => u.UserName).Skip(PageSize * (PageNumber - 1)).Take(PageSize).ToListAsync();
                TotalUsersNumber = Users.Count();

            }

            PreviousNumber = (PageNumber - 1 < 1) ? 1 : PageNumber - 1;
            NextNumber = PageNumber + 1;
            return Page();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage(new { Filter, PageNumber = 1 });
        }
    }
}
