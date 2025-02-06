using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Group_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Contracts.Entities.Player_Related
{
    public interface IPlayerFriendRepository : IGenericRepository<PlayerFriend>
    {
        // getter methods //

        Task<PlayerFriend?> GetEntity(Guid requesterId,
            Guid addresseeID, CancellationToken cancellationToken = default);

        Task<ICollection<Player>?> GetPlayerFriendshipsAsync(Guid targetUserId,
            CancellationToken cancellationToken = default);

        Task<FriendshipStatus> GetFriendshipStatusAsync(PlayerFriend friendship,
            CancellationToken cancellationToken = default);


        // setter methods //

        Task SetFriendshipStatusAsync(PlayerFriend friendship, FriendshipStatus status,
           CancellationToken cancellationToken = default);

    }
}
