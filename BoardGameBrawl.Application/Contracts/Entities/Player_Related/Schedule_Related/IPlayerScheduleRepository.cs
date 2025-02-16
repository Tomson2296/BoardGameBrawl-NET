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

namespace BoardGameBrawl.Application.Contracts.Entities.Player_Related.Schedule_Related
{
    public interface IPlayerScheduleRepository : IGenericRepository<PlayerSchedule>, IAuditableRepository<PlayerSchedule>
    {
        // getter methods //

        Task<PlayerSchedule?> GetPlayerScheduleByPlayerId(Guid playerId,
            CancellationToken cancellationToken = default);

        Task<PlayerSchedule?> GetPlayerScheduleWithDetails(Guid playerId,
            CancellationToken cancellationToken = default);

        Task<bool> CheckIfPlayerScheduleExists(Guid playerId,
            CancellationToken cancellationToken = default);

        // Add or updates UserSchedule object
        Task AddOrUpdateAsync(PlayerSchedule playerSchedule,
            CancellationToken cancellationToken = default);



        // Add or updates singular DailyAvailability object
        Task AddOrUpdateDailyAvailabilityAsync(Guid playerId, DailyAvailability availability,
            CancellationToken cancellationToken = default);

        // Add batch of DailyAvailability (when creating a new UserSchedule for first time)
        Task AddBatchOfDailyAvailabilityAsync(Guid playerId, List<DailyAvailability> dailyAvailabilities,
            CancellationToken cancellationToken = default);

        // Get singular DailyAvailability object with Time slots
        Task<DailyAvailability?> GetDailyAvailabilityAsync(Guid playerId, DayOfWeek day,
            CancellationToken cancellationToken = default);

        // Clear all time slots from one day
        Task ClearDayAsync(Guid playerId, DayOfWeek day, CancellationToken cancellationToken = default);



        // Adds or updates singular time slot 
        Task AddOrUpdateTimeSlotAsync(Guid playerId, DayOfWeek day, TimeSlot timeSlot,
            CancellationToken cancellationToken = default);

        // Add batch of TimeSlots and attach them to DailyAvailability object
        Task AddBatchOfTimeSlotsAsync(Guid playerId, DayOfWeek day,
            List<TimeSlot> timeSlots, CancellationToken cancellationToken = default);

        // Get singular taken time slot from one day
        Task<TimeSlot?> GetTimeSlotAsync(int timeSlotId, CancellationToken cancellationToken = default);

        // Remove singular taken time slot from one day
        Task RemoveTimeSlotAsync(int timeSlotId, CancellationToken cancellationToken = default);



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
