#nullable disable
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using BoardGameBrawl.Application.Exceptions;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Services
{
    public class ApplicationUserQueryService : IApplicationUserQueryService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IdentityAppDBContext _context;
        private readonly IMapper _mapper;

        public ApplicationUserQueryService(UserManager<ApplicationUser> userManager,
            IdentityAppDBContext context,
            IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        private bool _disposed = false;
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    _context.Dispose();
                }
                // Mark as disposed.
                _disposed = true;
            }
        }

        public async Task<ViewUserDTO> GetUserPropertiesAsync(
            Guid applicationUserId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(applicationUserId);

            var user = await _userManager.Users
                .Where(u => u.Id.Equals(applicationUserId))
                .AsNoTracking()
                .ProjectTo<ViewUserDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);

            return user ?? throw new NotFoundException("User", user);
        }

        public async Task<ICollection<NavUserDTO>> GetFilteredUsersByUsernameAsync(
            int pageSize,
            int pageNumber,
            string filter = "",
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _userManager.Users
                .Where(u => string.IsNullOrEmpty(filter) || u.UserName!.Contains(filter))
                .AsNoTracking()
                .OrderBy(u => u.UserName)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ProjectTo<NavUserDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<NavUserDTO>> GetFilteredUsersByAppRoleAsync(
            int pageSize,
            int pageNumber,
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(roleId);

            return await _userManager.Users
               .OrderBy(u => u.UserName)
               .Where(u => u.UserRoles.Any(r => r.RoleId == roleId))
               .AsNoTracking()
               .Skip(pageSize * (pageNumber - 1))
               .Take(pageSize)
               .ProjectTo<NavUserDTO>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }

        public async Task<ApplicationUserLogin> GetExternalLoginData(string loginProvider, 
            string providerKey, 
            Guid userId, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(loginProvider))
            {
                throw new ArgumentException("LoginProvider cannot be null or whitespace.", nameof(loginProvider));
            }

            if (string.IsNullOrWhiteSpace(providerKey))
            {
                throw new ArgumentException("Provider Key cannot be null or whitespace.", nameof(providerKey));
            }

            var externalLoginData = await _context.UserLogins.FindAsync(new { loginProvider, providerKey }, cancellationToken);
            return externalLoginData ?? throw new NotFoundException("ExternalLoginData", externalLoginData);
        }

        public async Task<IList<ApplicationUserLogin>> GetExternalLoginsByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(userId);

            return await _context.UserLogins
                .Where(ul => ul.UserId == userId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<ApplicationUserLogin>> GetListOfAllExternalLoginsAsync(
            int pageSize,
            int pageNumber,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _context.UserLogins
                .AsNoTracking()
                .OrderBy(ul => ul.UserId)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
