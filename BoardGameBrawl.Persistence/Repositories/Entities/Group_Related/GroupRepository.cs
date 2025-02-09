using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Group_Related
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        private readonly IMapper _mapper;

        public GroupRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        // custom methods // 

        public async Task<IList<NavGroupDTO>> GetFilteredBatchOfGroupsAsync(string filter, int size, int skip = 0, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (size <= 0)
                throw new ArgumentException("Batch size must be greater than zero.", nameof(size));

            try
            {
                return await Context.Groups
                    .Where(g => g.GroupName.Contains(filter))
                    .OrderBy(g => g.GroupName)
                    .ProjectTo<NavGroupDTO>(_mapper.ConfigurationProvider)
                    .Skip(skip)
                    .Take(size)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving a batch of entities.", ex);
            }
        }


        // getter methods //

        public Task<string> GetGroupNameAsync(Group group,
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
