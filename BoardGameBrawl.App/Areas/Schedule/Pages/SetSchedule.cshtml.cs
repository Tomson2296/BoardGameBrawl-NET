#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByAppUserId;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.AddOrUpdateSchedule;
using BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.GetPlayerScheduleWithDetails;
using System.ComponentModel.DataAnnotations;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.RemoveSchedule;
using System;
using BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.GetDailyAvailabilityByDay;
using BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.AddOrUpdateDaily;
using BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.AddDefaultTImeSlot;
using Microsoft.Identity.Client;
using Microsoft.Extensions.DependencyModel;

namespace BoardGameBrawl.App.Areas.Schedule.Pages
{
    public class SetScheduleModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public SetScheduleModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public PlayerDTO TargetPlayer { get; set; }

        public PlayerScheduleDTO PlayerSchedule { get; set; }

        [BindProperty]
        public ScheduleViewModel Schedule { get; set; }

        public class ScheduleViewModel
        {
            public Guid Id { get; set; }
            public Guid PlayerId { get; set; }
            public List<DayViewModel> Days { get; set; } = new List<DayViewModel>();
        }

        public class DayViewModel
        {
            public int Id { get; set; }
            public Guid PlayerScheduleId { get; set; }
            public DayOfWeek DayOfWeek { get; set; }
            public List<TimeSlotViewModel> TimeSlots { get; set; } = new List<TimeSlotViewModel>();
        }

        public class TimeSlotViewModel
        {
            public int Id { get; set; }
            public int DailyAvailabilityId { get; set; }

            [Required]
            [DataType(DataType.Time)]
            public TimeSpan StartTime { get; set; }

            [Required]
            [DataType(DataType.Time)]
            public TimeSpan EndTime { get; set; }
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var query = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
            TargetPlayer = await _mediator.Send(query);

            // get PlayerSchedule
            var check = new GetPlayerScheduleWithDetailsQuery { PlayerId = TargetPlayer.Id };
            PlayerSchedule = await _mediator.Send(check);

            // setting ScheduleModelView nad populate it with DTO fetch data
            Schedule = new ScheduleViewModel
            {
                Id = PlayerSchedule.Id,
                PlayerId = PlayerSchedule.PlayerId,
                Days = PlayerSchedule.DailyAvailabilities.Select(d => new DayViewModel
                {
                    Id = d.Id,
                    PlayerScheduleId = d.PlayerScheduleId,
                    DayOfWeek = d.DayOfWeek,
                    TimeSlots = d.TimeSlots!.Select(t => new TimeSlotViewModel
                    {
                        Id = t.Id,
                        DailyAvailabilityId = t.DailyAvailabilityId,
                        StartTime = t.StartTime,
                        EndTime = t.EndTime
                    }).ToList()
                }).ToList()
            };
            
            return Page();
        }

        public IActionResult OnPostBackToIndex()
        {
            return RedirectToPage("Index");
        }


        public async Task<IActionResult> OnPostAddNewTimeSlotAsync(int dailyId, DayOfWeek dayOfWeek)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
                return Page();

            try
            {
                var query = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
                TargetPlayer = await _mediator.Send(query);

                // create new default TimeSlotDTO
                TimeSlotDTO newTimeSlotDTO = new()
                {
                    DailyAvailabilityId = dailyId,
                    StartTime = default,
                    EndTime = default
                };

                // add new TimeSlot object
                var updateSchedule = new AddDefaultTimeSlotCommand { playerId = TargetPlayer.Id, day = dayOfWeek, timeSlot = newTimeSlotDTO };
                var result = await _mediator.Send(updateSchedule);

                if (result.Success)
                {
                    StatusMessage = "New default time slot added successfully";
                    return RedirectToPage();
                }
                else
                {
                    StatusMessage = "Error during update process of player schedule: " + result.Message;
                    return Page();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = "Error - something unexpected happened during updating player schedule " + ex.Message;
                return Page();
            }
        }


        public async Task<IActionResult> OnPostSaveDailyAsync(int DailyId, DayOfWeek dayOfWeek)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
                return Page();

            try
            {
                // parse DayOfWeek into int
                var targetInt = (int)dayOfWeek;

                // get user object
                var query = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
                TargetPlayer = await _mediator.Send(query);

                // fetch exisiting daily availability
                var getDailyAvailability = new GetDailyAvailabilityQuery { PlayerId = TargetPlayer.Id, DayOfWeek = dayOfWeek };
                var fetchedDAily = await _mediator.Send(getDailyAvailability);

                if (fetchedDAily == null)
                {
                    ModelState.AddModelError("", "Daily availability not found.");

                    StatusMessage = "Error during process of saving daily - Daily not found";
                    return Page();
                }

                // check if time slots overlap each other
                if (Schedule.Days.ElementAt(targetInt).TimeSlots != null && Schedule.Days.ElementAt(targetInt).TimeSlots.Any())
                {
                    var sortedSlots = Schedule.Days.ElementAt(targetInt).TimeSlots.OrderBy(ts => ts.StartTime).ToList();
                    for (int i = 0; i < sortedSlots.Count - 1; i++)
                    {
                        // If the current slot ends after the next slot starts, there is an overlap.
                        if (sortedSlots[i].EndTime > sortedSlots[i + 1].StartTime)
                        {
                            ModelState.AddModelError("", $"Overlapping time slots detected on {Schedule.Days.ElementAt(targetInt).DayOfWeek}. Please adjust the times.");
                            return Page();
                        }
                    }
                }

                // create DailyAvailabilityDTO object
                DailyAvailabilityDTO newDailyAvailabilityDTO = new()
                {
                    Id = DailyId,
                    PlayerScheduleId = fetchedDAily.PlayerScheduleId,
                    DayOfWeek = dayOfWeek,
                    TimeSlots = Schedule.Days.ElementAt(targetInt).TimeSlots.Select(ts => new TimeSlotDTO {
                        Id = ts.Id, 
                        DailyAvailabilityId = DailyId,
                        StartTime = ts.StartTime,
                        EndTime = ts.EndTime
                    }).ToList()
                };

                // add new daily for Player Schedule
                var addNewDaily = new AddOrUpdateDailyCommand { playerId = TargetPlayer.Id, DailyAvailabilityDTO = newDailyAvailabilityDTO };
                var result = await _mediator.Send(addNewDaily);

                if (result.Success)
                {
                    StatusMessage = "Update daily ended successfully";
                    return RedirectToPage();
                }
                else
                {
                    StatusMessage = "Error during update process of player schedule: " + result.Message;
                    return Page();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = "Error - something unexpected happened during updating player schedule " + ex.Message;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostSaveScheduleAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
                return Page();

            try
            {
                var query = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
                TargetPlayer = await _mediator.Send(query);

                // get PlayerSchedule
                var check = new GetPlayerScheduleWithDetailsQuery { PlayerId = TargetPlayer.Id };
                PlayerSchedule = await _mediator.Send(check);

                // check if time slots overlap each other
                foreach (var day in Schedule.Days)
                {
                    if (day.TimeSlots != null && day.TimeSlots.Any())
                    {
                        var sortedSlots = day.TimeSlots.OrderBy(ts => ts.StartTime).ToList();
                        for (int i = 0; i < sortedSlots.Count - 1; i++)
                        {
                            // If the current slot ends after the next slot starts, there is an overlap.
                            if (sortedSlots[i].EndTime > sortedSlots[i + 1].StartTime)
                            {
                                ModelState.AddModelError("", $"Overlapping time slots detected on {day.DayOfWeek}. Please adjust the times.");
                                StatusMessage = $"Error - Overlapping time slots detected on {day.DayOfWeek}. Please adjust the times.";
                                return Page();
                            }
                        }
                    }
                }

                PlayerScheduleDTO playerScheduleDTO = new PlayerScheduleDTO
                {
                    Id = Schedule.Id,
                    PlayerId = Schedule.PlayerId,
                    DailyAvailabilities = Schedule.Days.Select(d => new DailyAvailabilityDTO
                    {
                        Id = d.Id,
                        PlayerScheduleId = d.PlayerScheduleId,
                        DayOfWeek = d.DayOfWeek,
                        TimeSlots = d.TimeSlots!.Select(t => new TimeSlotDTO
                        {
                            Id = t.Id,
                            DailyAvailabilityId = t.DailyAvailabilityId,
                            StartTime = t.StartTime,
                            EndTime = t.EndTime
                        }).ToList()
                    }).ToList()
                };

                // update PlayerSchedule object
                var updateSchedule = new AddOrUpdateScheduleCommand { PlayerScheduleDTO = playerScheduleDTO };
                var result = await _mediator.Send(updateSchedule);

                if (result.Success)
                {
                    StatusMessage = "Update schedule ended successfully";
                    return RedirectToPage();
                }
                else
                {
                    StatusMessage = "Error during update process of player schedule: " + result.Message;
                    return Page();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = "Error - something unexpected happened during updating player schedule " + ex.Message;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostRemoveScheduleAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }

                var query = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
                TargetPlayer = await _mediator.Send(query);

                // remove Player Schedule object
                var removePlayerSchedule = new RemoveScheduleCommand { PlayerId = TargetPlayer.Id };
                var result = await _mediator.Send(removePlayerSchedule);

                if (result.Success)
                {
                    StatusMessage = "Removing Player Schedule completed successfully";
                    return RedirectToPage("/Index", new { area = "" });
                }
                else
                {
                    StatusMessage = "Error during deletion process of player schedule: " + result.Message;
                    return Page();
                }
            }
            catch (Exception ex)
            {
                StatusMessage = "Error - something unexpected happened during updating player schedule " + ex.Message;
                return Page();
            }
        }
    }
}
