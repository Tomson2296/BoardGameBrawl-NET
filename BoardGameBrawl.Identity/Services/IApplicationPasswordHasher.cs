using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Identity.Services
{
    public interface IApplicationPasswordHasher<TUser> where TUser : class
    {
        public string[] HashPasswordExtended(TUser user, string password);

        public Task<PasswordVerificationResult> VerifyHashedPasswordAsync(TUser user, string providedPassword);

        public bool ComparePasswords(string hashedPassword, string storedPassword);
    }
}
