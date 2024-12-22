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
    public class ApplicationUserRoleStore(IdentityAppDBContext context) : ApplicationUserStore(context), IUserRoleStore<ApplicationUser>
    {
        private readonly IdentityAppDBContext context = context;
        public async Task AddToRoleAsync(ApplicationUser user, string roleName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(roleName);

            var roleEntity = await context.Roles.FirstOrDefaultAsync(r => r.Name!.Equals(roleName), cancellationToken);

            if (roleEntity != null)
            {
                var newUserRole = new ApplicationUserRole() { UserId = user.Id, RoleId = roleEntity.Id };
                await context.UserRoles.AddAsync(newUserRole, cancellationToken);
            }
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            var query = from userRole in context.UserRoles
                        where userRole.UserId.Equals(user.Id)
                        join role in context.Roles on userRole.RoleId equals role.Id
                        select role.Name;

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNullOrWhiteSpace(roleName);

            var query = from user in context.Users
                        join role in context.Roles on user.Id equals role.Id
                        where role.Name == roleName
                        select user;

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<bool> IsInRoleAsync(ApplicationUser user, string roleName,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(roleName);

            var role = await context.Roles.FirstOrDefaultAsync(r => r.Name!.Equals(roleName), cancellationToken);

            if (role != null)
            {
                var userId = user.Id;
                var roleId = role.Id;
                return await context.UserRoles.AnyAsync(ur => ur.RoleId.Equals(roleId) && ur.UserId.Equals(userId), cancellationToken);
            }
            return false;
        }

        public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(roleName);

            var role = await context.Roles.FirstOrDefaultAsync(r => r.Name == roleName, cancellationToken);
            var userRole = await context.UserRoles.FirstOrDefaultAsync(r => r.UserId == user.Id && r.RoleId == role!.Id, cancellationToken);

            context.UserRoles.Remove(userRole!);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
