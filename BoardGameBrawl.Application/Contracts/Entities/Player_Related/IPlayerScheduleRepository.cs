using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Contracts.Entities.Player_Related
{
    public interface IPlayerScheduleRepository : IGenericRepository<PlayerSchedule>, IAuditableRepository<PlayerSchedule>
    {
        // getter methods //

        Task<PlayerSchedule?> GetPlayerScheduleByPlayerId(Guid playerId,
            CancellationToken cancellationToken = default);

        Task<PlayerSchedule?> GetPlayerScheduleWithDetails(Guid playerId,
            CancellationToken cancellationToken = default);

        Task AddOrUpdateAsync(PlayerSchedule playerSchedule,
            CancellationToken cancellationToken = default);

        // Add or updates DailyAvailability object
        Task AddOrUpdateDailyAvailabilityAsync(Guid playerId, DailyAvailability availability,
            CancellationToken cancellationToken = default);

        // Adds or updates time slot 
        Task AddOrUpdateTimeSlotAsync(Guid playerId, DayOfWeek day, TimeSlot timeSlot,
            CancellationToken cancellationToken = default);

        // Remove singular taken time slot from one day
        Task RemoveTimeSlotAsync(int timeSlotId, CancellationToken cancellationToken = default);

        // Clear all time slots from one day
        Task ClearDayAsync(Guid playerId, DayOfWeek day, CancellationToken cancellationToken = default);

        // Check if a player is available on a specific day/time
        Task<bool> IsAvailableAsync(Guid playerId, DayOfWeek day, TimeSpan startTime, TimeSpan endTime,
            CancellationToken cancellationToken = default);

        // Get all available time slots for a day
        Task<IEnumerable<TimeSlotDTO>> GetTimeSlotsForDayAsync(Guid playerId, DayOfWeek day,
            CancellationToken cancellationToken = default);

        // Get all players available on a specific day/time range
        Task<IEnumerable<NavPlayerDTO>> GetAvailablePlayersAsync(DayOfWeek day, TimeSpan startTime, TimeSpan endTime,
            CancellationToken cancellationToken = default);

        // Check for overlapping time slots in a day
        Task<bool> HasOverlappingSlotsAsync(Guid playerId, DayOfWeek day, TimeSpan startTime, TimeSpan endTime,
            CancellationToken cancellationToken = default);

        // Validate time slot (e.g., start < end)
        bool IsTimeSlotValid(TimeSpan start, TimeSpan end, CancellationToken cancellationToken = default);
    }
}
