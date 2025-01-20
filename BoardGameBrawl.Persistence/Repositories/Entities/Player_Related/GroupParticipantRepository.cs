using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Player_Related
{
    public class GroupParticipantRepository : GenericRepository<GroupParticipant> , IGroupParticipantRepository
    {
        public GroupParticipantRepository(MainAppDBContext context) : base(context)
        {
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

        public async Task<bool> GetAdminStatusAsync(GroupParticipant groupParticipant,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(groupParticipant);

            return await Task.FromResult(groupParticipant.IsAdmin);
        }

        public async Task<ICollection<Group>> GetAllPlayerGroupsByIdAsync(Guid playerId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);

            var query = from groups in Context.Groups
                        join groupParticipants in Context.GroupParticipants
                        on groups.Id equals groupParticipants.GroupId
                        where groupParticipants.PlayerId == playerId
                        select groups;

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<ICollection<Player>> GetAllUserParticipantsInGroupByIdAsync(Guid groupId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(groupId);

            var query = from players in Context.Players
                        join groupParticipants in Context.GroupParticipants
                        on players.Id equals groupParticipants.PlayerId
                        where groupParticipants.GroupId == groupId
                        select players;

            return await query.ToListAsync(cancellationToken);
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
