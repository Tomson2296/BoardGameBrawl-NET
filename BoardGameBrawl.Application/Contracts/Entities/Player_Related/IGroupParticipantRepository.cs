using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Contracts.Entities.Player_Related
{
    public interface IGroupParticipantRepository : IGenericRepository<GroupParticipant>
    {
        // getter methods //

        Task<GroupParticipant?> GetGroupParticipantAsync(Guid groupId,
            Guid playerId, CancellationToken cancellationToken = default);

        Task<ICollection<BoardGameBrawl.Domain.Entities.Group_Related.Group>> GetAllPlayerGroupsByIdAsync(Guid playerId,
           CancellationToken cancellationToken = default);

        Task<ICollection<Player>> GetAllUserParticipantsInGroupByIdAsync(Guid groupId,
            CancellationToken cancellationToken = default);
        
        Task<bool> GetAdminStatusAsync(GroupParticipant groupParticipant,
            CancellationToken cancellationToken = default);


        // setter methods //

        Task SetAdminStatusAsync(GroupParticipant groupParticipant, bool isAdmin,
            CancellationToken cancellationToken= default);  
    }
}
