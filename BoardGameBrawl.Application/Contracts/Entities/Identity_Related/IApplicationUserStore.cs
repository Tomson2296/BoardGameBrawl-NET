using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Application.Contracts.Entities.Identity_Related
{
    public interface IApplicationUserStore<TUser> : IUserStore<TUser>,
        IUserEmailStore<TUser>,
        IUserClaimStore<TUser>,
        IUserConfirmation<TUser>,
        IUserLockoutStore<TUser>,
        IUserLoginStore<TUser>,
        IUserPasswordStore<TUser>,
        IUserRoleStore<TUser>,
        IUserSecurityStampStore<TUser> where TUser : class
    {
    }
}
