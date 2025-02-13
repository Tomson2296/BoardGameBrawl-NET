using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Group_Related
{
    public interface IGroupParticipantRepository : IGenericRepository<GroupParticipant>
    {
        // custom methods //

        Task<IList<NavPlayerDTO>> GetBatchOfUserParticipantsInGroupByIdAsync(Guid groupId,
            int size, int skip = 0, CancellationToken cancellationToken = default);

        Task<bool> CheckIfUserIsGroupParticipant(Guid groupId, Guid playerId,
            CancellationToken cancellationToken = default);

        Task<IList<NavPlayerDTO>> GetAllGroupAdminsAsync(Guid groupId,
            CancellationToken cancellationToken = default);


        // getter methods //

        Task<GroupParticipant?> GetGroupParticipantAsync(Guid groupId,
            Guid playerId, CancellationToken cancellationToken = default);

        Task<IList<NavGroupDTO>> GetAllPlayerGroupsByIdAsync(Guid playerId,
           CancellationToken cancellationToken = default);

        Task<IList<NavPlayerDTO>> GetAllUserParticipantsInGroupByIdAsync(Guid groupId,
            CancellationToken cancellationToken = default);

        
        Task<bool> GetAdminStatusAsync(GroupParticipant groupParticipant,
            CancellationToken cancellationToken = default);

        Task<bool> GetAdminStatusAsync(Guid groupId, Guid playerId,
           CancellationToken cancellationToken = default);


        // setter methods //

        Task SetAdminStatusAsync(GroupParticipant groupParticipant, bool isAdmin,
            CancellationToken cancellationToken= default);  
    }
}
