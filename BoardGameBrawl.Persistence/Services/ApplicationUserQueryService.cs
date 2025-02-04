using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Services
{
    public class ApplicationUserQueryService : IApplicationUserQueryService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public ApplicationUserQueryService(
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ICollection<NavUserDTO>> GetFilteredUsersByUsernameAsync(
            int pageSize,
            int pageNumber,
            string? filter = "",
            CancellationToken cancellationToken = default)
        {
            return await _userManager.Users
                .Where(u => string.IsNullOrEmpty(filter) || u.UserName!.Contains(filter))
                .AsNoTracking()
                .OrderBy(u => u.UserName)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ProjectTo<NavUserDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
