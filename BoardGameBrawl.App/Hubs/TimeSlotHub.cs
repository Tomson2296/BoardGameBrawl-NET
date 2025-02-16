using BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.AddOrUpdateTimeSlot;
using BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.RemoveTimeSlot;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace BoardGameBrawl.App.Hubs
{
    public class TimeSlotHub : Hub
    {
        private readonly IMediator _mediator;
        public TimeSlotHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task RemoveTimeSlot(string timeSlotId)
        {
            if (!int.TryParse(timeSlotId, out int parsedId))
            {
                return;
            }

            var command = new RemoveTimeSlotCommand { TimeSlotId = parsedId };
            var result = await _mediator.Send(command);

            if (result.Success)
            {
                // Notify all clients that the time slot has been removed.
                await Clients.All.SendAsync("TimeSlotRemoved", timeSlotId);
            }
            else
            {
                // Optionally, you could notify the caller about the failure.
                await Clients.Caller.SendAsync("Error", "Failed to remove time slot.");
            }
        }

        public async Task AddTimeSlot(string playerId, int dayOfWeek, int dailyAvailabilityId, string startTime, string endTime)
        {
            // parse PlayerId, day, and time slots 
            var player = Guid.Parse(playerId);
            var day = (DayOfWeek)dayOfWeek;
            var start = TimeSpan.Parse(startTime);
            var end = TimeSpan.Parse(endTime);

            // Create TimeSlotDTO object
            TimeSlotDTO timeSlotDTO = new()
            {
                StartTime = start,
                EndTime = end,
                DailyAvailabilityId = dailyAvailabilityId
            };

            // Create a command for adding a time slot. 
            // (Ensure your AddTimeSlotCommand includes a DailyAvailabilityId property.)
            var command = new AddOrUpdateTimeSlotCommand { playerId = player, day = day, timeSlot = timeSlotDTO };
            var result = await _mediator.Send(command);

            if (result.Success)
            {
                await Clients.All.SendAsync("TimeSlotAdded", dailyAvailabilityId, result.Success);
            }
            else
            {
                await Clients.Caller.SendAsync("Error", "Failed to add time slot.");
            }
        }

    }
}
