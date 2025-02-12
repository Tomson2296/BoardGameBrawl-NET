using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Group_Related
{
    public class GroupParticipantRepository : GenericRepository<GroupParticipant> , IGroupParticipantRepository
    {
        private readonly IMapper _mapper;
        public GroupParticipantRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        // getter methods //

        public async Task<GroupParticipant?> GetGroupParticipantAsync(Guid groupId, 
            Guid playerId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(groupId);
            ArgumentNullException.ThrowIfNull(playerId);

            var participantInDB = await Context.GroupParticipants.FirstOrDefaultAsync(e => e.GroupId == groupId && e.PlayerId == playerId, cancellationToken);
            
            if (participantInDB != null)
                return participantInDB;
            else
                throw new ApplicationException("Entity has not been found");
        }

        public Task<bool> GetAdminStatusAsync(GroupParticipant groupParticipant,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(groupParticipant);

            return Task.FromResult(groupParticipant.IsAdmin);
        }

        public async Task<IList<NavGroupDTO>> GetAllPlayerGroupsByIdAsync(Guid playerId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);

            return await _context.Groups
                .Where(g => g.GroupParticipants!.Any(par => par.PlayerId == playerId))
                .ProjectTo<NavGroupDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<NavPlayerDTO>> GetAllUserParticipantsInGroupByIdAsync(Guid groupId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(groupId);

            return await _context.Players
              .Where(g => g.GroupParticipants!.Any(par => par.GroupId == groupId))
              .ProjectTo<NavPlayerDTO>(_mapper.ConfigurationProvider)
              .AsNoTracking()
              .ToListAsync(cancellationToken);
        }

        // setter methods //

        public Task SetAdminStatusAsync(GroupParticipant groupParticipant, 
            bool isAdmin, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(isAdmin);

            groupParticipant.IsAdmin = isAdmin;
            return Task.CompletedTask;
        }
    }
}
