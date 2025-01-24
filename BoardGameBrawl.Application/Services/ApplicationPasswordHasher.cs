using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Application.Services
{
    public class ApplicationPasswordHasher : IPasswordHasher<ApplicationUser>
    {
        public string HashPassword(ApplicationUser user, string password)
        {
            string passwordSalt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, passwordSalt, false, hashType: BCrypt.Net.HashType.SHA512);
            return passwordHash;
        }

        public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
        {
            ArgumentNullException.ThrowIfNull(user);

            if (string.IsNullOrWhiteSpace(hashedPassword))
            {
                throw new ArgumentException("Hashed password cannot be null or whitespace.", nameof(hashedPassword));
            }

            if (string.IsNullOrWhiteSpace(providedPassword))
            {
                throw new ArgumentException("Provided password cannot be null or whitespace.", nameof(providedPassword));
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword, false, hashType: BCrypt.Net.HashType.SHA512);

            return isPasswordValid
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
        }
    }
}
