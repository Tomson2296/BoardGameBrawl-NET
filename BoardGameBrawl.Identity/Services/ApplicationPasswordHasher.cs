using BCrypt.Net;
using BoardGameBrawl.Identity.Entities;
using BoardGameBrawl.Identity.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

namespace BoardGameBrawl.Identity.Services
{
    public class ApplicationPasswordHasher : IApplicationPasswordHasher<ApplicationUser>
    {
        private readonly IUserStore<ApplicationUser> _userStore;

        public ApplicationPasswordHasher(IUserStore<ApplicationUser> userStore)
        {
            _userStore = userStore;
        }

        public string HashPassword(ApplicationUser user, string password)
        {
            string passwordSalt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, passwordSalt, false, hashType: BCrypt.Net.HashType.SHA512);
            return passwordHash;
        }

        public async Task<PasswordVerificationResult> VerifyHashedPasswordAsync(ApplicationUser user, string providedPassword)
        {
            string? storedHash = await _userStore.GetUserPasswordHash(user);

            if (storedHash.IsNullOrEmpty())
            {
                return PasswordVerificationResult.Failed;
            }
            
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(providedPassword, storedHash, false, hashType: BCrypt.Net.HashType.SHA512);

            return isPasswordValid
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
        }
    }
}
