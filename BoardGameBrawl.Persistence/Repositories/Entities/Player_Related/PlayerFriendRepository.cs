using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Player_Related
{
    public class PlayerFriendRepository : GenericRepository<PlayerFriend>, IPlayerFriendRepository
    {
        private readonly IMapper _mapper;

        public PlayerFriendRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
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

        public async Task<Guid> GetFriendshipId(Guid requesterId, Guid addresseeID, CancellationToken cancellationToken = default)
        {

            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(requesterId);
            ArgumentNullException.ThrowIfNull(addresseeID);

            var participantInDB = await _context.PlayerFriends
                .FirstOrDefaultAsync(e => e.RequesterId == requesterId && e.AddresseeId == addresseeID, cancellationToken);

            if (participantInDB != null)
            {
                return participantInDB.Id;
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

        public async Task<IList<NavPlayerDTO>> GetPlayerFriendshipsAsync(Guid targetUserId, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(targetUserId);

            return await _context.Players
                    .Where(p =>
                        // Check if player is in any accepted friendship with current user
                        _context.PlayerFriends.Any(pf =>
                            (pf.RequesterId == targetUserId && pf.AddresseeId == p.Id && pf.Status == FriendshipStatus.Accepted) ||
                            (pf.AddresseeId == targetUserId && pf.RequesterId == p.Id && pf.Status == FriendshipStatus.Accepted)
                        )
                    )
                    .ProjectTo<NavPlayerDTO>(_mapper.ConfigurationProvider)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
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
