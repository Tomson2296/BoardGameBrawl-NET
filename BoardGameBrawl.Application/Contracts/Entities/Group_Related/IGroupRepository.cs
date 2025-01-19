using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Group_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Group_Related
{
    public interface IGroupRepository : IGenericRepository<Group>, IAuditableRepository<Group>
    {
        // getter methods // 

        public Task<string?> GetGroupNameAsync(Group group,
          CancellationToken cancellationToken = default);

        public Task<string?> GetGroupDescriptionAsync(Group group,
           CancellationToken cancellationToken = default);

        public Task<byte[]?> GetGroupMiniatureAsync(Group group,
          CancellationToken cancellationToken = default);

        // setter methods //

        public Task SetGroupNameAsync(Group group,
           string? groupName,
           CancellationToken cancellationToken = default);

        public Task SetGroupDescriptionAsync(Group group,
           string? desc,
           CancellationToken cancellationToken = default);

        public Task SetGroupMiniatureAsync(Group group,
          byte[]? miniature,
          CancellationToken cancellationToken = default);
    }
}
