using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Group_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Group_Related
{
    public interface IGroupRepository : IGenericRepository<Group>, IAuditableRepository<Group>
    {
        // getter methods // 

        Task<string?> GetGroupNameAsync(Group group,
          CancellationToken cancellationToken = default);

        Task<string?> GetGroupDescriptionAsync(Group group,
           CancellationToken cancellationToken = default);

        Task<byte[]?> GetGroupMiniatureAsync(Group group,
          CancellationToken cancellationToken = default);

        // setter methods //

        Task SetGroupNameAsync(Group group,
           string? groupName,
           CancellationToken cancellationToken = default);

        Task SetGroupDescriptionAsync(Group group,
           string? desc,
           CancellationToken cancellationToken = default);

        Task SetGroupMiniatureAsync(Group group,
          byte[]? miniature,
          CancellationToken cancellationToken = default);
    }
}
