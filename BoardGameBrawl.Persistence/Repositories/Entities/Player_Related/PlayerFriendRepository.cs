using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Player_Related
{
    public class PlayerFriendRepository : GenericRepository<PlayerFriend>, IPlayerFriendRepository
    {
        public PlayerFriendRepository(MainAppDBContext context) : base(context)
        {

        }

        public async Task<PlayerFriend?> GetEntity(Guid requesterId, 
            Guid addresseeID, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(requesterId);
            ArgumentNullException.ThrowIfNull(addresseeID);

            var participantInDB = await Context
                .PlayerFriends
                .FirstOrDefaultAsync(e => e.RequesterId == requesterId && e.AddresseeId == addresseeID, cancellationToken);

            if (participantInDB != null)
            {
                return participantInDB;
            }
            else
            {
                throw new ApplicationException("Entity has not been found");
            }
        }

        public Task<FriendshipStatus> GetFriendshipStatusAsync(PlayerFriend friendship, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(friendship);

            return Task.FromResult(friendship.Status);
        }
        
        public async Task<ICollection<Player>?> GetPlayerFriendshipsAsync(Guid targetUserId, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(targetUserId);

            var query = from players in Context.Players
                        join requesters in Context.PlayerFriends
                        on players.Id equals requesters.RequesterId
                        join addresse in Context.PlayerFriends
                        on players.Id equals addresse.AddresseeId
                        where players.Id == targetUserId
                        select players;

            return await query.Distinct().ToArrayAsync(cancellationToken);
        }

        public Task SetFriendshipStatusAsync(PlayerFriend friendship,
            FriendshipStatus status, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(friendship);
            ArgumentNullException.ThrowIfNull(status);

            friendship.Status = status;
            return Task.CompletedTask;
        }
    }
}
