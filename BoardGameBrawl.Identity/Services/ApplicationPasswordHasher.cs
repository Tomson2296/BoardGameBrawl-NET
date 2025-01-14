using BoardGameBrawl.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Identity.Services
{
    public class ApplicationPasswordHasher : IPasswordHasher<ApplicationUser>
    {
        public string HashPassword(ApplicationUser user, string password)
        {
            string hashedpassword = BCrypt.Net.BCrypt.EnhancedHashPassword(password, BCrypt.Net.HashType.SHA512, 12);
            return hashedpassword;
        }

        public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword)
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
        }
    }
}
