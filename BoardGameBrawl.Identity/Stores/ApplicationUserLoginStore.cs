using BoardGameBrawl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Identity.Stores
{
    public class ApplicationUserLoginStore(IdentityAppDBContext context) : ApplicationUserStore(context), IUserLoginStore<ApplicationUser>
    {
        private readonly IdentityAppDBContext context = context;

        public async Task AddLoginAsync(ApplicationUser user, UserLoginInfo login, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(login);

            var userLoginInDB = await context.UserLogins.FindAsync(login.LoginProvider, login.ProviderKey, cancellationToken);

            if (userLoginInDB == null)
            {
                var newUserLoginCredentials = new ApplicationUserLogin()
                {
                    LoginProvider = login.LoginProvider,
                    ProviderKey = login.ProviderKey,
                    ProviderDisplayName = login.ProviderDisplayName
                };

                await context.UserLogins.AddAsync(newUserLoginCredentials, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<ApplicationUser?> FindByLoginAsync(string loginProvider, string providerKey,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNullOrWhiteSpace(loginProvider);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(providerKey);

            var query = from userLogin in context.UserLogins
                        where userLogin.LoginProvider.Equals(loginProvider)
                        where userLogin.ProviderKey.Equals(providerKey)
                        join user in context.Users on userLogin.UserId equals user.Id
                        select user;

            return await query.SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            var appUserLogin =  await context.UserLogins
                .Where(ul => ul.UserId == user.Id)
                .ToListAsync(cancellationToken);

            return await Task.FromResult((IList<UserLoginInfo>)appUserLogin);
        }

        public async Task RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(loginProvider);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(providerKey);

            var userLoginInDB = await context.UserLogins.FindAsync(loginProvider, providerKey, cancellationToken);

            if (userLoginInDB != null)
            {
                context.UserLogins.Remove(userLoginInDB);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
