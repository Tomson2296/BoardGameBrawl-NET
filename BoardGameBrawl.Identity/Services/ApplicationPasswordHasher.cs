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
            bool ifSuccessfulHash = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword, false, BCrypt.Net.HashType.SHA512);
            
            return ifSuccessfulHash
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
        }
    }
}
