﻿using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Persistence.Services
{
    public class ApplicationUserCommandService : IApplicationUserCommandService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IdentityAppDBContext _context;

        public ApplicationUserCommandService(UserManager<ApplicationUser> userManager,
            IdentityAppDBContext context)
        {
            _userManager = userManager;
            _context = context;
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

        public Task<bool> RemoveExternalLoginAsync(string? LoginProvider, 
            string? ProviderKey, 
            Guid userId, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
