using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Player_Related
{
    public class PlayerScheduleRepository : GenericRepository<PlayerSchedule>, IPlayerScheduleRepository
    {
        private readonly IMapper _mapper;

        public PlayerScheduleRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<PlayerSchedule?> GetPlayerScheduleByPlayerId(Guid playerId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);

            return await _context.PlayerSchedules
             .FirstOrDefaultAsync(ps => ps.PlayerId == playerId, cancellationToken);
        }

        public async Task<PlayerSchedule?> GetPlayerScheduleWithDetails(Guid playerId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);

            return await _context.PlayerSchedules
                .Include(ps => ps.DailyAvailabilities!)
                .ThenInclude(da => da.TimeSlots)
                .FirstOrDefaultAsync(ps => ps.PlayerId == playerId, cancellationToken);
        }

        public async Task AddOrUpdateAsync(PlayerSchedule playerSchedule, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerSchedule);

            // Try to find an existing schedule for the player.
            var existingSchedule = await _context.PlayerSchedules!
            .Include(ps => ps.DailyAvailabilities!)
                .ThenInclude(da => da.TimeSlots)
            .FirstOrDefaultAsync(ps => ps.PlayerId == playerSchedule.PlayerId, cancellationToken);


            if (existingSchedule == null)
            {
                // Add the new schedule.
                await _context.PlayerSchedules.AddAsync(playerSchedule, cancellationToken);
            }
            else
            {
                // Update top-level properties.
                _context.Entry(existingSchedule).CurrentValues.SetValues(playerSchedule);

                // For DailyAvailabilities, a more refined merge may be required.
                // Here, we clear and re-add for simplicity.

                if (playerSchedule.DailyAvailabilities != null)
                {
                    existingSchedule.DailyAvailabilities?.Clear();
                    foreach (var availability in playerSchedule.DailyAvailabilities)
                    {
                        existingSchedule.DailyAvailabilities?.Add(availability);
                    }
                }
            }
        }

        public async Task AddOrUpdateDailyAvailabilityAsync(Guid playerId, DailyAvailability availability,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);
            ArgumentNullException.ThrowIfNull(availability);

            var schedule = await GetPlayerScheduleByPlayerId(playerId);

            if (schedule == null)
            {
                // If the schedule doesn't exist, create one with the provided availability.
                schedule = new PlayerSchedule
                {
                    PlayerId = playerId,
                    DailyAvailabilities = new List<DailyAvailability> { availability }
                };
                await _context.PlayerSchedules.AddAsync(schedule, cancellationToken);
            }
            else
            {
                // Find an existing DailyAvailability for the same day.
                var existingAvailability = schedule.DailyAvailabilities?
                    .FirstOrDefault(da => da.DayOfWeek == availability.DayOfWeek);

                if (existingAvailability == null)
                {
                    // Add the new availability.
                    if (schedule.DailyAvailabilities == null)
                        schedule.DailyAvailabilities = new List<DailyAvailability>();
                    schedule.DailyAvailabilities.Add(availability);
                }
                else
                {
                    // Update the existing availability.
                    _context.Entry(existingAvailability).CurrentValues.SetValues(availability);
                }
            }
        }

        public async Task AddOrUpdateTimeSlotAsync(Guid playerId, DayOfWeek day, TimeSlot timeSlot,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);
            ArgumentNullException.ThrowIfNull(day);
            ArgumentNullException.ThrowIfNull(timeSlot);

            // Load the player's schedule along with DailyAvailabilities and TimeSlots.
            var schedule = await GetPlayerScheduleWithDetails(playerId);

            if (schedule == null)
            {
                // Create a new schedule if needed.
                schedule = new PlayerSchedule
                {
                    PlayerId = playerId,
                    DailyAvailabilities = new List<DailyAvailability>()
                };
                await _context.PlayerSchedules.AddAsync(schedule, cancellationToken);
            }

            // Find the DailyAvailability for the specified day.
            var dailyAvailability = schedule.DailyAvailabilities?
                .FirstOrDefault(da => da.DayOfWeek == day);

            if (dailyAvailability == null)
            {
                // If not found, create a new DailyAvailability with the new TimeSlot.
                dailyAvailability = new DailyAvailability
                {
                    DayOfWeek = day,
                    TimeSlots = new List<TimeSlot> { timeSlot }
                };

                if (schedule.DailyAvailabilities == null)
                    schedule.DailyAvailabilities = new List<DailyAvailability>();
                schedule.DailyAvailabilities.Add(dailyAvailability);
            }
            else
            {
                // Check if the time slot exists (by its Id) and update or add accordingly.
                var existingTimeSlot = dailyAvailability.TimeSlots?
                    .FirstOrDefault(ts => ts.Id == timeSlot.Id);

                if (existingTimeSlot == null)
                {
                    if (dailyAvailability.TimeSlots == null)
                        dailyAvailability.TimeSlots = new List<TimeSlot>();
                    dailyAvailability.TimeSlots.Add(timeSlot);
                }
                else
                {
                    existingTimeSlot.StartTime = timeSlot.StartTime;
                    existingTimeSlot.EndTime = timeSlot.EndTime;
                }
            }
        }

        public async Task ClearDayAsync(Guid playerId, DayOfWeek day, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);
            ArgumentNullException.ThrowIfNull(day);

            // Load the schedule with details.
            var schedule = await GetPlayerScheduleWithDetails(playerId, cancellationToken);

            if (schedule != null)
            {
                var dailyAvailability = schedule.DailyAvailabilities?
                    .FirstOrDefault(da => da.DayOfWeek == day);
                if (dailyAvailability != null && dailyAvailability.TimeSlots != null)
                {
                    dailyAvailability.TimeSlots.Clear();
                }
            }
        }


        public async Task<IEnumerable<NavPlayerDTO>> GetAvailablePlayersAsync(DayOfWeek day, TimeSpan startTime, TimeSpan endTime,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(startTime);
            ArgumentNullException.ThrowIfNull(endTime);
            ArgumentNullException.ThrowIfNull(day);

            // Query for players that have at least one DailyAvailability for the specified day
            // with a TimeSlot covering the requested time range.

            return await _context.Players
                .Include(p => p.PlayerSchedule!)
                    .ThenInclude(ps => ps.DailyAvailabilities!)
                        .ThenInclude(da => da.TimeSlots)
                .Where(p => p.PlayerSchedule!.DailyAvailabilities!.Any(da => da.DayOfWeek == day &&
                    da.TimeSlots!.Any(ts => ts.StartTime <= startTime && ts.EndTime >= endTime)))
                .ProjectTo<NavPlayerDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }


        public async Task<IEnumerable<TimeSlotDTO>> GetTimeSlotsForDayAsync(Guid playerId, DayOfWeek day,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);
            ArgumentNullException.ThrowIfNull(day);

            var schedule = await _context.PlayerSchedules!
                .Include(ps => ps.DailyAvailabilities!)
                    .ThenInclude(da => da.TimeSlots)
                .FirstOrDefaultAsync(ps => ps.PlayerId == playerId, cancellationToken);

            if (schedule == null)
                return Enumerable.Empty<TimeSlotDTO>();

            var dailyAvailability = schedule.DailyAvailabilities?
                .FirstOrDefault(da => da.DayOfWeek == day);

            if (dailyAvailability == null || dailyAvailability.TimeSlots == null)
                return Enumerable.Empty<TimeSlotDTO>();

            return _mapper.Map<ICollection<TimeSlotDTO>>(dailyAvailability.TimeSlots);
        }

        public async Task<bool> HasOverlappingSlotsAsync(Guid playerId, DayOfWeek day, TimeSpan startTime, TimeSpan endTime,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);
            ArgumentNullException.ThrowIfNull(startTime);
            ArgumentNullException.ThrowIfNull(endTime);
            ArgumentNullException.ThrowIfNull(day);

            // Load the schedule with the related DailyAvailabilities and TimeSlots.
            var schedule = await GetPlayerScheduleWithDetails(playerId, cancellationToken);

            if (schedule == null)
                return false;

            var dailyAvailability = schedule.DailyAvailabilities?
                .FirstOrDefault(da => da.DayOfWeek == day);

            if (dailyAvailability == null || dailyAvailability.TimeSlots == null)
                return false;

            // Check if any two TimeSlots overlap using the common condition:
            // One slot's start is before the other's end and vice versa.
            bool hasOverlap = dailyAvailability.TimeSlots.Any(ts => ts.StartTime < endTime && startTime < ts.EndTime);
            return hasOverlap;
        }

        public async Task<bool> IsAvailableAsync(Guid playerId, DayOfWeek day, TimeSpan startTime, TimeSpan endTime,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);
            ArgumentNullException.ThrowIfNull(day);
            ArgumentNullException.ThrowIfNull(startTime);
            ArgumentNullException.ThrowIfNull(endTime);

            // Load the schedule with DailyAvailabilities and TimeSlots.
            var schedule = await GetPlayerScheduleWithDetails(playerId, cancellationToken);

            if (schedule == null)
                return false;

            var dailyAvailability = schedule.DailyAvailabilities?
                .FirstOrDefault(da => da.DayOfWeek == day);

            if (dailyAvailability == null || dailyAvailability.TimeSlots == null)
                return false;

            // Consider the player available if any TimeSlot fully covers the requested range.
            var availableSlot = dailyAvailability.TimeSlots
                .FirstOrDefault(ts => ts.StartTime <= startTime && ts.EndTime >= endTime);

            return availableSlot != null;
        }

        public bool IsTimeSlotValid(TimeSpan start, TimeSpan end, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(start);
            ArgumentNullException.ThrowIfNull(end);

            // A time slot is valid if the start time is earlier than the end time.
            return start < end;
        }

        public async Task RemoveTimeSlotAsync(int timeSlotId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Find and remove the TimeSlot by its Id.
            var timeSlot = await _context.Set<TimeSlot>().FindAsync(new object[] { timeSlotId }, cancellationToken);
            
            if (timeSlot != null)
            {
                _context.Set<TimeSlot>().Remove(timeSlot);
            }
        }
    }
}
