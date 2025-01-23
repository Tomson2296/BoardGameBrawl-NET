using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Identity.Services
{
    public interface IApplicationPasswordHasher<TUser> where TUser : class
    {
        public string HashPassword(TUser user, string password);

        public Task<PasswordVerificationResult> VerifyHashedPasswordAsync(TUser user, string providedPassword);
    }
}
