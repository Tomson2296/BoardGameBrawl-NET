using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Group_Related
{
    public class GroupParticipantRepository : GenericRepository<GroupParticipant>, IGroupParticipantRepository
    {
        private readonly IMapper _mapper;
        public GroupParticipantRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        // custom methods //

        public async Task<IList<NavPlayerDTO>> GetBatchOfUserParticipantsInGroupByIdAsync(Guid groupId,
            int size, int skip = 0, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(groupId);

            if (size <= 0)
                throw new ArgumentException("Batch size must be greater than zero.", nameof(size));

            try
            {
                return await Context.Players
                    .Where(p => p.GroupParticipants!.Any(gp => gp.GroupId == groupId))
                    .OrderBy(p => p.PlayerName)
                    .ProjectTo<NavPlayerDTO>(_mapper.ConfigurationProvider)
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


        public async Task<IList<NavPlayerDTO>> GetAllGroupAdminsAsync(Guid groupId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(groupId);

            return await _context.Players
                .Where(p => p.GroupParticipants!.Any(gp => gp.IsAdmin == true))
                .ProjectTo<NavPlayerDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> CheckIfUserIsGroupParticipant(Guid groupId, Guid playerId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(groupId);
            ArgumentNullException.ThrowIfNull(playerId);

            return await _context.GroupParticipants.AnyAsync(e => e.GroupId == groupId && e.PlayerId == playerId, cancellationToken);
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

        public async Task<bool> GetAdminStatusAsync(Guid groupId, Guid playerId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(groupId);
            ArgumentNullException.ThrowIfNull(playerId);

            var participantInDB = await Context.GroupParticipants.FirstOrDefaultAsync(e => e.GroupId == groupId && e.PlayerId == playerId, cancellationToken);
            if (participantInDB != null)
            {
                return participantInDB.IsAdmin;
            }
            else
            {
                throw new ApplicationException("Entity has not been found");
            }
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
