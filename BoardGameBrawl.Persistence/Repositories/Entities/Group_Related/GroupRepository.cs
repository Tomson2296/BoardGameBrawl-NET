using BoardGameBrawl.Application.Contracts.Entities.Group_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;
using BoardGameBrawl.Persistence.Repositories.Common;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Group_Related
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(MainAppDBContext context) : base(context)
        {
        }


        // getter methods //

        public Task<string?> GetGroupNameAsync(Group group,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(group);

            return Task.FromResult(group.GroupName);
        }

        public Task<string?> GetGroupDescriptionAsync(Group group, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(group);

            return Task.FromResult(group.GroupDescription);
        }

        public Task<byte[]?> GetGroupMiniatureAsync(Group group,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(group);

            return Task.FromResult(group.GroupMiniature);
        }


        // setter methods //
        
        public Task SetGroupNameAsync(Group group, string? groupName, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(group);

            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentException("Group name cannot be null or whitespace.", nameof(groupName));
            }

            group.GroupName = groupName;
            return Task.CompletedTask;
        }

        public Task SetGroupDescriptionAsync(Group group, string? desc, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(group);

            if (string.IsNullOrWhiteSpace(desc))
            {
                throw new ArgumentException("Group description cannot be null or whitespace.", nameof(desc));
            }

            group.GroupDescription = desc;
            return Task.CompletedTask;
        }

        public Task SetGroupMiniatureAsync(Group group, byte[]? miniature, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(group);
            ArgumentNullException.ThrowIfNull(miniature);

            group.GroupMiniature = miniature;
            return Task.CompletedTask;
        }
    }
}
