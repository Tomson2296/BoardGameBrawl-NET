using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Group_Related
{
    public interface IGroupParticipantRepository : IGenericRepository<GroupParticipant>
    {
        // getter methods //

        Task<GroupParticipant?> GetGroupParticipantAsync(Guid groupId,
            Guid playerId, CancellationToken cancellationToken = default);

        Task<ICollection<GroupDTO>> GetAllPlayerGroupsByIdAsync(Guid playerId,
           CancellationToken cancellationToken = default);

        Task<ICollection<NavPlayerDTO>> GetAllUserParticipantsInGroupByIdAsync(Guid groupId,
            CancellationToken cancellationToken = default);
        
        Task<bool> GetAdminStatusAsync(GroupParticipant groupParticipant,
            CancellationToken cancellationToken = default);


        // setter methods //

        Task SetAdminStatusAsync(GroupParticipant groupParticipant, bool isAdmin,
            CancellationToken cancellationToken= default);  
    }
}
