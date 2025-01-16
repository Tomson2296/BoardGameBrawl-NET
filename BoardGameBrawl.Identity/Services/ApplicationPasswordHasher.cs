using BoardGameBrawl.Identity.Entities;
using BoardGameBrawl.Identity.Stores;
using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Identity.Services
{
    public class ApplicationPasswordHasher : IApplicationPasswordHasher<ApplicationUser>
    {
        private readonly IUserStore<ApplicationUser> _userStore;

        public ApplicationPasswordHasher(IUserStore<ApplicationUser> userStore)
        {
            _userStore = userStore;
        }

        public string[] HashPasswordExtended(ApplicationUser user, string password)
        {
            string passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, passwordSalt, false, hashType: BCrypt.Net.HashType.SHA512);
            return new[] { passwordSalt, passwordHash };
        }

        public async Task<PasswordVerificationResult> VerifyHashedPasswordAsync(ApplicationUser user, string providedPassword)
        {
            string? storedHash = await _userStore.GetUserPasswordHash(user);
            string? storedSalt = await _userStore.GetUserPasswordSalt(user);

            string comparePassword = BCrypt.Net.BCrypt.HashPassword(providedPassword, storedSalt, false, hashType: BCrypt.Net.HashType.SHA512);
            bool ifSuccessfulHash = ComparePasswords(comparePassword, storedHash);
            
            return ifSuccessfulHash
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
        }
        
        public bool ComparePasswords(string? hashedPassword, string? storedPassword)
        {
            return string.Equals(hashedPassword, storedPassword);
        }
    }
}
